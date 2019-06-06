# Installing ProGrids

To install ProGrids in your Unity Project, follow these steps:

1. Navigate to your Project directory. 
2. Open **manifest.json** inside the **UnityPackageManager** directory. 
3. Add the ProGrids package as a dependency:

```
{
	"dependencies": {
		"com.unity.progrids": "3.0.0"
	},
	"registry":"http://staging-packages.unity.com"
}
```

Verify that ProGrids is correctly installed by opening **Tools** > **ProGrids** > **About**.

## Upgrading from early versions of ProGrids

To upgrade a Unity Project with ProGrids already present:

1. Open the Project in Unity 2018.1 or later.
1. Delete the **ProGrids** folder in the Project view.
2. Edit the **manifest.json** as described above.
