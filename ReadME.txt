
///////////////////////////// IP to localhsot

Command execution (as administrator)

netsh http add urlacl url=http://computer:50036/ user=Everyone
change computer for yours and do this for each page you want to work: like pc name, ip adrees.
helped to change a mistake with 400 on 503

Now to see my wsdl, I just added a reference

<Binding Protocol="http" bindingInformation="*:50233:computer" /> 
<Binding Protocol="http" bindingInformation="*:50233:192.168.0.11" /> 
<Binding Protocol="http" bindingInformation="*:50233:localhost" /> 


//////////////////////////////// PAyPAl return

index of cart

<input type="hidden" name="return" value="http://your-IP-address:50036/Cart">