﻿# HDB Converter

HDB Converter stands for Hexadecimal Decimal Binary Converter. That is, a converter between number systems.

## Story

The first version in winforms was created sometime in 2015, as my personal project for my work at the time, when I didn't enjoy using the Windows calculator to convert between systems. It handled the conversion well, but it was a lot of clicking.

Now, at my work is preparing to work on a client application in WPF (I hope the management will drop it and we will do it for the web), so I revived this micro project and converted it to WPF to get to know it a little.

## Description

The emphasis is on simplicity and ease of use. Therefore, the application can:
1. Close with Esc
2. Copy with Ctrl + C without having to select the text
3. Move with the arrows as if it were a three-line text field - i.e. the up/down arrow in the outer lines will cause the cursor to jump to the home/end position

## Still to be done:

1. Final publish as the application should be (version, manifest?, certificate?).
2. License - I don't know if it is necessary at all
3. Better, not native design
4. Steps between rows should keep caret possition, if some row length is smaller.
5. Saving state (last active textbox and the text inside) - can continue after restart the app.
6. Convert bigger numbers than ulong (BigInteger?)
7. MAUI or different GUI for multipratform usage

## How to build

Just clone this repository and build it. There is no third party libraries. Only you need is Visual Studio (i use 2022) and .net 9.
