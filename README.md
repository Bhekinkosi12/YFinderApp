# YFinder Server-Side Capstone

## YFinder is a Xamarin Forms mobile iOS app for students and professionals to rate their favorite hotspots to work and study. It uses iPhone's GPS and WiFi sensors to gauge location coordinates and connectivity strength. It is powered by YFinder C#/NET Core 2.0 API, custom written for this app. 

<hr>

## Users can login or register, view hotspots with at least one user's rating, decide where they'd like to post up, and then navigate to that location with seamless integration with Apple Maps. Reviews can be left for the benefit of all users to improve their decision of where to work or study.

<hr>

###  Deployment
 - YFinder is deployed under a limited Apple provisioning signature which means it is tied to a single phyiscal device. You can view it in a simulator of your choice by cloning the repo and running it a simulator of your choice like [XCode's](https://developer.apple.com/xcode/downloads/). 
 - In order for the app to access the database, clone [this](https://github.com/mitchellblom/YFinderAPIdotnet2) API I wrote for it. Run in the IDE of choice or execute `dotnet run` on the command line. View directions in the API repo if you haven't already executed the database build. API deployment coming soon.
 - Replace API local hosting link if applicable on the StaticVariablesExample page.
 - I'd also be happy to demo this app with you in person - contact me via www.mitchellblom.com

<hr>

###  Technologies
* C#
* Xamarin & Xamarin.Forms
* ASP.NET Core 2.0 Web API 
* Entity Framework, LINQ

<hr>

### Screen Shots

#### Landing
![Landing](https://raw.githubusercontent.com/mitchellblom/YFinderApp/master/YFinder/Screenshots/01-landing.png)

#### Login
![Login](https://raw.githubusercontent.com/mitchellblom/YFinderApp/master/YFinder/Screenshots/02-login.png)

#### Welcome
![Welcome](https://raw.githubusercontent.com/mitchellblom/YFinderApp/master/YFinder/Screenshots/03-welcome.png)

#### Menu Options
![Menu Options](https://raw.githubusercontent.com/mitchellblom/YFinderApp/master/YFinder/Screenshots/04-menu.png)

#### Map Interaction
![Map Interaction](https://raw.githubusercontent.com/mitchellblom/YFinderApp/master/YFinder/Screenshots/05-map.png)

#### Hotspot Details
![Hotspot Details](https://raw.githubusercontent.com/mitchellblom/YFinderApp/master/YFinder/Screenshots/06-hotspot.png)

#### Directions
![Directions](https://raw.githubusercontent.com/mitchellblom/YFinderApp/master/YFinder/Screenshots/07-directions.png)

#### Reviews
![Reviews](https://raw.githubusercontent.com/mitchellblom/YFinderApp/master/YFinder/Screenshots/08-reviews.png)

#### New Review
![New Review](https://raw.githubusercontent.com/mitchellblom/YFinderApp/master/YFinder/Screenshots/09-new.png)

#### User List
![User List](https://raw.githubusercontent.com/mitchellblom/YFinderApp/master/YFinder/Screenshots/10-users.png)

#### Profile
![Profile](https://raw.githubusercontent.com/mitchellblom/YFinderApp/master/YFinder/Screenshots/11-profile.png)
