# gong-test-1
Test case for Gong WPF Drag Drop library

## Compiler used
* Visual Studio 2017
* .NET Framework 4.6.2

## Library used
* gong-wpf-dragdrop version 2.0.3

## Intended Behaviour
(Note that the actual action on drop has been disabled for the purposes of this test case; the focus is what happens when dragging.)

* You should be able to drag the items in Group 1 up and down to reorder them within the same list.
* You should be able to drag the items in Group 1 to the "Group 2" tab header to move them from Group 1 to Group 2.
* You should be able to drag the items in Group 1 to the red box to delete them.
* You should be able to drag the items in Group 2 to the red box to delete them.
* You cannot drag the items in Group 2 to reorder them, or to anywhere except the red box.
* One of the Drag or Effect adorners should indicate what happens when you drag it over each unique target.
** Initially I just wanted to use the Effect adorner by itself, but when I ran into the clipping and templating problems I switched to using the Drag adorner by itself, since that better supported target-based templates.
** For the purposes of this test case I've left both enabled just so that you can see the separate issues with each approach.

## Unintended behaviour
* The Effect adorner clips past the edge of the window when you drag over the red box (while the Drag adorner does not).
* There doesn't appear to be any way to show entirely different content in the Effect adorner based on drop target (although it is possible to do some limited data customisation, as demonstrated).
** There also doesn't appear to be any way to define a template in the XAML which can access the `EffectText`/`DestinationText`; instead something weirder in the code is required.
* When dragging Group 2 items over the Group 2 listbox, the Drag adorners for the tab header are displayed.
** The intended behaviour is to not show anything (or at most to show a "no drop" cursor), because this is not a valid drop target for those items. 

## Attempts to resolve this that didn't work
* Setting an `EffectMoveAdornerTemplate` on the drag target.
* Setting `dd:DragDrop.DropAdornerTemplate="{x:Null}"` on the `ListBox` inside Group 2.
* Setting the `EventType` to `Bubble` on the `TabItem`.
* Probably some other things that I've forgotten.
