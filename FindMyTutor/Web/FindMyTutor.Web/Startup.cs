using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FindMyTutor.Data;
using FindMyTutor.Data.Models;
using FindMyTutor.Common;
using FindMyTutor.Data.Services.Subjects;
using FindMyTutor.Data.Services.Messages;
using FindMyTutor.Data.Services.Comments;
using FindMyTutor.Data.Services.Recommendations;
using FindMyTutor.Data.Services.Reviews;
using FindMyTutor.Data.Services.Users;
using FindMyTutor.Data.Services.Offers;
using Microsoft.AspNetCore.Mvc.Razor;
using AutoMapper;
using FindMyTutor.Web.ViewModels.Offers.Profiles;
using FindMyTutor.Web.ViewModels.Comments.Profiles;
using FindMyTutor.Web.Authorization.Policies;
using FindMyTutor.Web.Authorization.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Net;
using FindMyTutor.Web.ViewModels.Messages.Profiles;
using FindMyTutor.Web.Helpers;
using FindMyTutor.Data.Services.Logs;
using FindMyTutor.Web.Areas.Admin.Models.Profiles;
using FindMyTutor.Data.Services.Reports;
using FindMyTutor.Web.ViewModels.Notifications.Profiles;
using FindMyTutor.Data.Services.Notifications;

namespace FindMyTutor.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<FindMyTutorWebContext>(options =>
                    options.UseSqlServer(
                        this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddIdentity<FindMyTutorUser, IdentityRole>(option =>
               {
                   option.Password.RequiredLength = 6;
                   option.Password.RequireDigit = true;
                   option.Password.RequireUppercase = true;
                   option.Password.RequireNonAlphanumeric = false;
                   option.User.RequireUniqueEmail = true;


               })
                .AddEntityFrameworkStores<FindMyTutorWebContext>();

          

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Constants.Policy.MustBeTutor, policy =>
                            policy.RequireRole(Constants.Role.Tutor));
                options.AddPolicy(Constants.Policy.MustBeCreator, policy =>
                            policy.Requirements.Add(new CheckRolePermission(Constants.Role.Tutor)));
                options.AddPolicy(Constants.Policy.MessageRequirement,
                    policy => policy.Requirements.Add(new MessageRequirement()));

            });

    

            services.AddSingleton<IAuthorizationHandler, RequireRoleHandler>();
            services.AddSingleton<IAuthorizationHandler, CheckRolePermissionHandler>();
            services.AddSingleton<IAuthorizationHandler, MustNotBeLoggedInHandler>();
            services.AddSingleton<IAuthorizationHandler, AuthorizeMessageHandler>();

            services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<IRecommendationService, RecommendationService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<INotificationService, NotificationService>();

            services.AddRouting();
            var mapperConfig = new MapperConfiguration(mc =>
           {
               mc.AddProfile<OfferProfile>();
               mc.AddProfile<CommentProfile>();
               mc.AddProfile<MessageProfile>();
               mc.AddProfile<LogProfile>();
               mc.AddProfile<ReportProfile>();
               mc.AddProfile<NotificationProfile>();
           });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddRazorPagesOptions(options => 
            {               
                options.AllowAreas = true;
            });

            

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);               
                options.AccessDeniedPath = Constants.Path.AccessDeniedPath;                             
                options.SlidingExpiration = true;
                
            });
        }
        
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "Admin",
                    template: "{area:exists}/{controller=Account}/{action=Dashboard}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
