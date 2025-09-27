# Portasys
This is a small library for portable enviroments AKA "self-contained programs". This treats any drive that's not the C drive as an external hard drive and assumes that the root of the drive is okay to create its "System" folder.

I've taken the liberty of mimicing the folde naming conventions of Windows,MacOS,and Linux. This library will set your current working directory as the root, even if you decide to burry it after your initial close.
