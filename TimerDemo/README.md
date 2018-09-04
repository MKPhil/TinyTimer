My kids wanted an app that showed them how long they'd been using the PC that day to help them manage their screen usage, and nothing I could find really satisfed me, so I decided to roll my own!

## Features:
* Always on top
* Drag the window to move
* Puts an icon in Notification Area (aka System Tray), not Taskbar
* Double-click icon in Notification Area to hide, double-click again to show
* Cannot close by usual methods! No menu or close button, no Alt-F4! Can only be killed by Task Manager or by using a super-secret Key combination (this is left as an exercise for the reader (read the source!))
* Timer pauses if the user logs out, uses Switch User, on Hibernate or Sleep
* Zero-footprint - Doesn't store anything on local file system or in the registry
* Resets each day or at midnight if you're logged on then!

## Caveats:
* If user logs off completely and on again (or reboots the computer) the timer resets (i.e. doesn't remember the earlier session)
* Cannot change colours, window size

## What it doesn't do:
* Control, log or limit screen time (I have other solutions for that)
