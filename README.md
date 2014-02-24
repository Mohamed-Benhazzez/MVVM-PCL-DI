MVVM-PCL-DI
===========

Windows Phone 8 & Windows 8 sample applications exposing how to build cross platform applications.

This code is the support of the following tutorial 
http://blogtechno.novediagroup.com/bonnes-pratiques-pour-une-application-windows-phone-etou-windows-store
All the explanations are contained in the tutorial (French only for now).

This code allow having a functional application on Windows Phone 8 and Windows 8, they get data from:
http://parisdata.opendatasoft.com/api/records/1.0/search?dataset=maneges_et_jeux_2012&facet=arrt&facet=categorie_de_jeux_forains
And display the extracted object. 

It show how to use 
-Model View View-Model pattern using MvvmLight with separated layers of code, data binding and relay commands.
-Dependency Injections with swappable and upgradable services following fixed contracts (interfaces)
-Portable Class Library with code sharing between the two platforms.
