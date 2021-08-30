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
	if (passwd == "75684848868943554384"){
		cout << "Hi there";
		cout << "vous pouvez taper ce même mot de passe dans 'validation' / you can type this same password in 'validation' section ";

	}
	else {
		cout << "bad password / mauvais mot de passe\n\n";
	}

	cout << "type some letters and press ENTER to continue...";
	int exit;
	cin >> exit;
	cout << exit;

	return 0;


}
