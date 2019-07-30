using System.ComponentModel;

namespace FindMyTutor.Data.Models
{
    public enum LogType
    {

        // The int values are the indexes that will determine the colour of the alert
        // Colours are placed in a static string array in the Constants class


        // Index 0 - Success
        [Description(" създаде оферта.")]
        CreatedAnOffer = 0,

        //Index 1 - Warning
        [Description(" редактира оферта.")]
        EditedAnOffer = 1,

        //Index 0 - Success
        [Description(" добави коментар.")]
        AddedAComment = 3,

        //Index 2 - Danger
        [Description(" докладва оферта.")]
        ReportedAnOffer = 2,

        [Description(" докладва коментар.")]
        ReportedAComment =5
    }
}