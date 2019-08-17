
///////////////////////////// IP to localhost

Command execution (as administrator)



First of all open applicationhost.config file in visual studio. address>>C:\Users\Your User Name\Documents\IISExpress\config\applicationhost.config

Then find this codes:

<site name="Your Site_Name" id="24">
        <application path="/" applicationPool="Clr4IntegratedAppPool"
        <virtualDirectory path="/" physicalPath="C:\Users\Your User         Name\Documents\Visual Studio 2013\Projects\Your Site Name" />
        </application>
         <bindings>      
           <binding protocol="http" bindingInformation="*:Port_Number:*" />
         </bindings>
   </site>

*)Port_Number:While your site running in IIS express on your computer, port number will visible in address bar of your browser like this: localhost:port_number/... When edit this file save it.

In the Second step you must run cmd as administrator and type this code: netsh http add urlacl url=http://*:port_Number/ user=everyone and press enter

In Third step you must Enable port on firewall

Go to the “Control Panel\System and Security\Windows Firewall”

Click “Advanced settings”

Select “Inbound Rules”

Click on “New Rule …” button

Select “Port”, click “Next”

Fill your IIS Express listening port number, click “Next”

Select “Allow the connection”, click “Next”

Check where you would like allow connection to IIS Express (Domain,Private, Public), click “Next”

Fill rule name (e.g “IIS Express), click “Finish”


//////////////////////////////// PAyPAl return

index of cart

<input type="hidden" name="return" value="http://your-IP-address:50036/Cart">
