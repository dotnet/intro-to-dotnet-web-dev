# Publish your web app to Azure!

Welcome! In this lesson, we'll teach you how to publish your web apps from the previous weeks' activities to Azure! We'll do this using Azure App Service.


## What is Azure App Services and why are we publishing our apps? 

Azure App Service is an HTTP-based service for hosting web applications, REST APIs, and mobile back ends. This service adds security, load balancing, autoscaling, automated management, and more to your applications. You can also take advantage of its DevOps capabilities, such as continuous deployment from Azure DevOps, GitHub, Docker Hub, and other sources, package management, staging environments, custom domain, and TLS/SSL certificates. 
You can learn more in the [Azure App Service overview documentation](https://docs.microsoft.com/azure/app-service/overview).

## Let's publish!
You can also find these instructions in the [Azure documentation](https://docs.microsoft.com/azure/app-service/quickstart-dotnetcore?tabs=net60&pivots=development-environment-vs).

1. In **Solution Explorer**, right-click your ASP.NET Core project and select **Publish**.
   ![Select publish in solution explorer](/images/solution-explorer-publish.png)
2. In **Publish**, you'll see the following options. Select **Azure** and click the **Next** button.
    ![Azure publish](/images/publish-new-app-service.png)
3. Choose the **Specific target**, **Azure App Service (Windows)**. Then, click the **Next** button.
   ![Choose specific target](/images/specific-target.png)
4. If you are not signed in to Azure or if your Visual Studio account is not linked to your Azure account, click **Add an account** or **Sign in**. If you are already signed in, select your account.
   ![Azure sign in](/images/sign-in-azure.png)

5. Select the **+** to the right of **App Service instances**.
   ![Create new app service](/images/publish-new-app-service.png)
6. For **Subscription**, accept the subscription that is listed or select a new one from the drop-down list.
7. For **Resource group**, select **New**. In **New resource group name**, enter *myResourceGroup* and select **OK**.
8. For **Hosting Plan**, select **New**.
9.  In the **Hosting Plan: Create new** dialog, enter the values specified in the following table:
   ![Hosting Plan](/images/hosting-plan.png)
9.  TODO TABLE
10. Select **Create** to create the Azure resources. Once the wizard completes, the Azure resources are created for you and you're ready to publish your ASP.NET Core project.
    ![Create Azure resources](create-new-app-service.png)
11. In the **Publish** dialog, ensure your new App Service app is selected in **App Service instance**, then select **Finish**. Visual Studio creates a publish profile for you for the selected App Service app.
12. In the **Publish** page, select **Publish**. If you see a warning message, select **Continue**.Visual Studio builds, packages, and publishes the app to Azure, and then launches the app in the default browser.

