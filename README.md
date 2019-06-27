# Project - FindMyTutor

## Type - A web app for offers

## Description

FindMyTutor is a simble web application that allows people to upload and look through 
offers for private lessons. Guest users can access login page, sign up and see the offers, 
but cannot react to them.

Regular users can contact tutors, can comment and review offers, can recommend tutors to their friends
and to the general public. They can also report offers and tutors who are not legitimate. 

Tutors can access all the functionality of a regular User, as well as creating and updating their own offers. 
If they think that a comment or a review is inappropriate, they can report it to the administrators. 

Administrators have all these rights as well as deleting inappropriate comments and shady offers. 

## Entities

### User
  - Id (string)
  - Username (string)
  - Password (string)
  - Email (string)
  - Full Name (string)
 public Role Role(can be User, Tutor or Admin)
        GivenRecommendations(List)
        ReceivedRecommendations(List)
        RecommendationsByFriends(List)
        SentMessages(List)
        ReveivedMessages(List)
        Comments(List)
		GivenReviews(List)
        ReceivedReviews(List)
        MadeOffers(List)
        RatingsCount(List)
        TotalRating (Integer)
### Product
  - Id (string)
  - Name (string)
  - Type (enum) (TV/AirConditioner/WashingMachine etc . . .)
  - Price (decimal)
  - ManufactoredOn (dateTime)
  - In Stock - (int:: quantity in stock)
### Order
  - Id (string)
  - IssuedOn (dateTime)
  - Quantity (int)
  - Product (Product)
  - Issuer (User)
### Credit Company
  - Id (string)
  - Name (string)
  - Active Since (dateTime)
  - Contracts (list of Contract)
### Credit Contracts
  - Id (string)
  - Issued On (dateTime)
  - Active Until (dateTime)
  - Price per Month (decimal)
  - Company (Credit Company)
  - Order (Order)
  - Contractor (User)# FindMyTutor
An open source project that helps people find a tutor
