You should each create your own folder with your scene & assets, and all materials/scripts, or anything that your scene is dependent on. You can then neatly export the whole folder as a pacakage.

When exporting, do not export dependencies (i.e. the shared scripts that will be in your team-mates project), only export your folder of new things you have created.

To Export:
- With your folder selected in the project panel
- Go to Assets > Export Package
- Make sure you see all the NEW things your scene needs to work
- Deselect export dependencies that are shared (e.g. any of my scripts, XR toolkit scripts etc that are in other folders)
- Zip up the package (best to put it in one folder inside another before zipping, otherwise Mac will unzip the package itself)
- Send to your teammate (via email or whatever)

One team member should then import all scenes into a fresh copy of the group project template so you can start working together as a group.

To Import:
- Go to Assets > Import > Custom Package
- Navigate to your team-mates package that they sent you
- Import, but before you confirm import, check that you aren't importing dependencies already in the project.

You can then choose whatever workflow suits you for collaboration.

