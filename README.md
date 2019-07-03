# About

This repo is an example of consuming a .NET Framework WCF service in a .NET Core API

This project is just to help understand what is involved in getting dotnet core to work with WCF.

# Details

There is not much out of the oridnary in terms of getting this to work. It is actually quite straight forward. The following steps were taken to setup the connection in dotnet core to "talk" to the WCF service. This is provided that the WCF service is already hosted. If the WCF service need to be hosted, check the `Hosting WCF Service` section for more details

  - Right click on `Connected Services` in the project
    - Click `Add Connected Service`
  - Click on `Microsoft WCF Web Service Reference Provider`
  - Insert the WSDL URI link in the dialog
  - Complete the wizard
  
This will create the code required to "talk" to the WCF service. The WCF Service will have a `Client` named after it that can be used.

From here, you can take a look in the `WCFController` for details on how to use the Client.

# Hosting WCF Service

If the WCF service needs to be hosted, the following steps can be performed to deploy and host it.

  - Ensure that there is a publish profile to publish the WCF service to the file system
    - If one does not exist you can create one by right clicking on the project and selecting `Publish`
    - Select Folder and Continue
  - Republish the WCF service with the file system publish
  - Go to the output directory and copy all the files
  - Place all the files in a IIS hosted directory
  - Navigate to the IIS hosted direcotry in the browser and go to `serviceName.svc`
  - This webpage should show you the WSDL page now, that you can use to put into the `Connected Services` reference

# How to test it out

  1. In order to test this out, you need to run have the WCF Service running/hosted in IIS under port 8080.
    - To do this, you will need to publish the WCF to the file system
    - Then take all the code from the publish folder and place it in the IIS directory
  2. You can then start up the dotnet core API
  3. Run the URL http://localhost:5000/wcf/echo?test=yourString
  4. See the response

## Alternative to hosting for WCF

Alternatively, you can host the WCF service anywhere, but you will need to update the service reference in the dotnet core API project.
