#include<iostream>
#include<string>
#include <stdio.h>
#include <string.h>
#include <process.h>
#include <winsock2.h>
#include <ws2tcpip.h>

using namespace std;

int main()
{
	cout << "passwd: ";
	string passwd;
	cin >> passwd;

    while (passwd != "crackmecpp")
    {
        cout << "mauvais mot de pass\nVEUILLEZ ENTER LE BON MOT DE PASSE/Bad password\nPLEASE ENTER THE CORRECT PASSWORD\n\n";
        cin >> passwd;

    }
    
	
	cout << "bad password / mauvais mot de passe\n\n";
	

	cout << "type some letters and press ENTER to continue...";
	int exit;
	cin >> exit;
	cout << exit;

	return 0;


}