XeroTechnicalTest consists of a CSharp console application created using Visual Studio 2013.

If you don't have Visual Studio available download the community edition from https://www.visualstudio.com/en-us/downloads/download-visual-studio-vs.aspx

Instructions for test are listed in the comments at the top of Program.cs.

Good luck!

#############################################################################################################################

Comments by Karan:
Thanks for the test, I thoroughly enjoyed showcasing my skills via this excercise.

I've used the following principles, features and skills in the test:
1. SOLID: Seperation of Concerns by forming classes for operations and services, Dependency Injection by introducing interfaces and injecting the interface in constructor for class usage.
2. DRY code: not repeating code by moving invoice lines to a separate repo and by removing redundant AddInvoiceLines in methods.
3. Async methods
4. Exception handling
5. Logging via a third party nuget package: log4net
6. Unit testing most scenarios for positive test cases
7. Having a clean folder structure
8. I've used SimpleInjector for implementing IoC container.
9. Having a Git repo to version control my code. This also enables reviewer to evaluate my individual commits.


#############################################################################################################################

I love feedback on my code, would appreciate comments for future improvements.

Thanks for taking the time to evaluate my code!
Cheers!
