🎉 BlinkStickNET for .NET 6.0! 🎉
======
Tested and working on Linux with a BlinkStick Nano.  

- The files in this branch are mostly stock. (not counting a few useless syntax modifications I'm too lazy to rollback.) 
- An example console app project has been included. Refer to the original work for more usage examples.
- I will not test the Windows code. Some of it has been commented.


Please Note
======
At least for Linux, you can't execute Read/Write commands to the device without permission.

You will need to create UDEV rules or do a terrible thing and use `sudo dotnet run`. 


What Changed?
======
A lot and nothing at the same time. 

- Cleaned out the solution & project files. Removed all local dependency and example files.
- Replaced the  `LibUsbDotNet <https://www.nuget.org/packages/LibUsbDotNet/2.2.29>`_ & `HidSharp <https://www.nuget.org/packages/HidSharp/2.1.0>`_ dependencies with their current stable NuGet versions.


What's Next?
======
Nothing. This repository will remain mostly as-is to preserve what's left of the integrity of the original product. 

I may accept a few bugfix related PRs over time, but I will refuse any request to modify the code.


Sincerely,
 \- The Administrator.
  
___________________________

___________________________

___________________________
  
Old ReadMe Reference
======

.. image:: http://www.blinkstick.com/images/logos/blinkstick-dotnet.png
   :alt: BlinkStickDotNet

This is BlinkStick .NET interface to control devices connected to the
computer. The library is written in Mono/.NET 4.0 C#.

What is BlinkStick? It's smart USB LED pixel. More info about it here:

http://www.blinkstick.com

API Reference
------------

http://arvydas.github.io/BlinkStickDotNet

Supported platforms
------------

* Windows
* Linux
* OSX

How to build (Windows)
----------------------

* Download and install `Microsoft .NET 4.0 Full <http://www.microsoft.com/en-gb/download/details.aspx?id=17718>`_
* Download and install `Xamarin Studio <http://monodevelop.com/Download>`_
* Alternatively you can use Microsoft Visual Studio 2010 and later
* All dependant libraries are inside the repository

Download the repository:

https://github.com/arvydas/BlinkStickDotNet/archive/master.zip

Extract it, open the solution file and build it.

Documentation and examples
------------

Please refer to Wiki:

https://github.com/arvydas/BlinkStickDotNet/wiki


Development
-----------

Join the development of BlinkStickDotNet library! Here is how you can contribute:

* Fork this repository
* Write some awesome code
* Issue a pull request

License
-------

BlinkStickDotNet is licensed under GPL v3. Please contact for other licensing options if required.

Maintainer
-----------

-  Arvydas Juskevicius - http://twitter.com/arvydev
