# Portasys
This is a small library for portable enviroments AKA "self-contained programs". This treats any drive that's not the C drive as an external hard drive and assumes that the root of the drive is okay to create its "System" folder.

My usage of the library is for my games and launchers that I plan to sell on flash drives. I gave everything non-specific names.

The folder structure:


    Root/

    System/
    
        Program/
        System/
        Images/
        ProgramData/

`Root` is either the root of the drive if the drive or the current woring directory, depending on if you're running the program in the C drive.
# Methods
`PortableEnviroment.GetFolder(SystemFolders specialFolder)`

Returns a path based on the SystemFolder. It's first run will find the root and generate the folders.

Download the source and build it, to your specific needs.
