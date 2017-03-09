# ClassToDataContract
Converts your class files into DataContract and DataMember architecture for WCF Services 


I needed to turn my object classes into DataContracts and DataMembers for a project. So, I searched for a tool to do this however 
there were nothing useful.Eventually I've found myself creating this one :)

The spaces given at Degistir method may differ from file to file so check the destination file before using.

Usage: 

  ClassToDataContract.exe fileToBeConverted.cs destinationFile.cs

If you don't specify a destination file the converted one will be saved as final.cs.

Have fun.
