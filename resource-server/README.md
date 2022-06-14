# Okta ASP.NET Web API Resource Server Example

This sample application authenticates requests against your Web API application, using access tokens.

The access tokens are obtained via the [Implicit Flow][].  As such, you will need to use one of our front-end samples with this project.  It is the responsibility of the front-end to authenticate the user, then use the obtained access tokens to make requests to this resource server.

## Prerequisites

Before running this sample, you will need the following:

* An Okta Developer Account, you can sign up for one at https://developer.okta.com/signup/.
* An Okta Application, configured for Single-Page App (SPA) mode. This is done from the Okta Developer Console and you can find instructions [here][OIDC SPA Setup Instructions].  When following the wizard, use the default properties.  They are are designed to work with our sample applications.
* One of our front-end sample applications to demonstrate the interaction with the resource server:
  * [Okta Angular Sample Apps][]
  * [Okta React Sample Apps][]
  * [Okta Vue Sample Apps][]

*Note:* This sample is pre-configured with an open CORS policy to make it easy to test with frontend projects. Make sure to restrict it to known origins in your production applications.

A typical resource-server requires a frontend and a backend application, so you will need to start each process:

## Running This Example

**backend:**

Clone this repo and replace the okta configuration placeholders in the `Web.Config` with your configuration values from the Okta Developer Console. 
You can see all the available configuration options in the [okta-aspnet GitHub](https://github.com/okta/okta-aspnet/blob/master/README.md).

> **NOTE:** The above command starts the resource server on port 8000. You can browse to `http://localhost:8000/api/messages` to ensure it has started. If you get the message "Authorization has been denied for this request", it indicates that the resource server is up. You will need to pass an access token to access the resource, which will be done by the front-end below.

**front-end:**

If you want to use one of our front-end samples, open a new terminal window and run the [front-end sample project of your choice](Prerequisites).  Once the front-end sample is running, you can navigate to http://localhost:8080 in your browser and log in to the front-end application.  Once logged in, you can navigate to the "Messages" page to see the interaction with the resource server.


[Implicit Flow]: https://developer.okta.com/authentication-guide/implementing-authentication/implicit
[Okta Angular Sample Apps]: https://github.com/okta/samples-js-angular
[Okta Vue Sample Apps]: https://github.com/okta/samples-js-vue
[Okta React Sample Apps]: https://github.com/okta/samples-js-react
[OIDC SPA Setup Instructions]: https://developer.okta.com/authentication-guide/implementing-authentication/implicit#1-setting-up-your-application