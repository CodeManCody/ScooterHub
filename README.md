Scooter Hub

Xamarin.Forms Mobile App

Ok guys, this repo/project structure is all set and in MVVM. Please watch some intro videos on MVVM and Xamarin.Forms so you can get a sense of how the project structure works. The goal is to keep as much shared codebase in the ScooterHub namespace (project) as possible while keeping our code loosely coupled. There are 4 projects/namespaces within this Visual Studio Solution:


	ScooterHub (shared amongst ALL platforms)

	ScooterHub.Android

	ScooterHub.iOS

	ScooterHub.UWP (Universal Windows Platform - Windows Phone, Tablet, Windows 10 	Desktop, etc.)


In the shared ScooterHub project, you will see description txt files for what goes in the View Models and Data Models folders (Data Model == Model). What goes in the Views (GUI) folder is pretty self-explanatory.

Lmk if you have any questions, and make sure YOUR solution builds and runs (just test on an Andriod emulator for now...mine is currently running Android Oreo 8.1, API 27...we can change our target and min OS ltr...you can run the iOS emulator if you have a Mac with Xcode on it...and the UWP should build and run if you are running Windows 10 or a stupid Windows phone haha).

*** If you feel inclined to start coding before we meet again, please make another branch and DO NOT merge/pull request into master for now. ***

BTW we will change this README to appropriate user oriented content when we are done lol.

Let's kick some ass!!

Cody

