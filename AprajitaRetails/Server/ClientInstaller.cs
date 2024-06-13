using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Stores;
using AprajitaRetails.Server.Models;

using AprajitaRetails.Shared.Models.Banking;

using AprajitaRetails.Shared.Models.Payroll;
using AprajitaRetails.Shared.Models.Vouchers;
using Microsoft.AspNetCore.Identity;

using AprajitaRetails.Server.Areas.Identity.Pages.Account;
using AprajitaRetails.Server.Models;
using AprajitaRetails.Shared.Models.Auth;
using Blazor.AdminLte;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AprajitaRetails.Server
{
    public class ClientInfo
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }

        public string Mobile { get; set; }
        public string Email { get; set; }
        public string GSTIN { get; set; }
        public string PanNo { get; set; }
        public DateTime StartDate { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonMobile { get; set; }
        public string OwnerName { get; set; }
        public string StoreCode { get; set; }

    }
    public class RegisteredClient
    {
        public AppClient Client { get; set; }
        public List<StoreGroup> Groups { get; set; }
        public List<Store> Stores { get; set; }
        public string RegisterAdminUserName { get; set; }
        public string DefaultPassword { get; set; }
        public string Remarks { get; set; }
        public Employee Owner { get; set; }
    }

}

namespace AprajitaRetails.Server
{
    //TODO: Implement this in fullcontext so it can be use any place 
    public class ClientInstaller
    {
        public static RegisteredClient RegisterClient(ARDBContext db, ApplicationDbContext context, ClientInfo info)
        {
            //TODO: Implement this in fullcontext so it can be use any place
            return null;
        }
        public static int InstallDefaultOptions(ARDBContext db, ApplicationDbContext context, DateTime? defDate, string storeid = "", string groupid = "", string eid = "")
        {


            defDate = defDate ?? DateTime.Now;
            //Create Default Admin User
            bool userCreated = false;
            var user = CreateUser();
            await _userStore.SetUserNameAsync(user, "Admin", CancellationToken.None);
            await _emailStore.SetEmailAsync(user, "admin@akslabs.in", CancellationToken.None);

            user.FullName = "Admin User";
            user.StoreId = storeid;
            user.EmployeeId = eid;

            user.StoreGroupId = groupid;
            user.Approved = true; user.Permission = RolePermission.Owner;


            var result = await _userManager.CreateAsync(user, "Admin@123");

            if (result.Succeeded)
            {
                //Do Conirmation here
                _logger.LogInformation("User created a new account with password.");
                var userId = await _userManager.GetUserIdAsync(user);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                if (_userManager.Options.SignIn.RequireConfirmedAccount)
                {
                    var result = await _userManager.ConfirmEmailAsync(user, code);
                    if (result.Succeeded)
                        userCreated = true;
                }
                else
                {
                    userCreated = true;
                }
            }

            //Create Bank Name
            var banks = [ new Bank{BankId="SBI",Name="State Bank Of India"},
            new Bank{BankId="HDFC",Name="HDFC Bank"}, new Bank{BankId="ICICI",Name="ICICI Bank"},
            new Bank{BankId="AXIS",Name="Axis Bank"}, new Bank{BankId="KOTAK",Name="Kotak Mahindra Bank"},
            new Bank{BankId="BOB",Name="Bank Of Baroda"}, new Bank{BankId="PUNJAB",Name="Punjab National Bank"},
            new Bank{BankId="IDBI",Name="IDBI Bank"}, new Bank{BankId="FEDERAL",Name="Federal Bank"},
            new Bank{BankId="IDFC",Name="IDFC Bank"}, new Bank{BankId="INDIAN",Name="Indian Bank"},
            new Bank{BankId="CANARA",Name="Canara Bank"}, new Bank{BankId="RBL",Name="RBL Bank"},
            new Bank{BankId="DBS",Name="DBS Bank"},          new Bank{BankId="UNION",Name="Union Bank"},
            new Bank{BankId="CITI",Name="Citi Bank"},          new Bank{BankId="YES",Name="Yes Bank"},
            new Bank(BankId="OTHERS",Name="Others"), new Bank{BankId="HSBC",Name="HSBC Bank"}
            ];
            db.Banks.AddRange(banks);
            int count = db.SaveChanges();

            //TransactionMode

            var TransactionModes = new List<TransactionMode>
            {
                new TransactionMode(TransactionId="CI",Name="Cash In"),
                new TransactionMode(TransactionId="CO",Name="CashOut"),
                new TransactionMode(TransactionId="PE",Name="Petty Cash Expenses"),
                new TransactionMode(TransactionId="AE",Name="Amit Expense"),
                new TransactionMode(TransactionId="HE",Name="Home Expense"),
                new TransactionMode(TransactionId="VE",Name="Vehicle Expense"),
                new TransactionMode(TransactionId="TE",Name="Telephone Expense"),
                new TransactionMode(TransactionId="ME",Name="Miscellaneous Expense"),
                new TransactionMode(TransactionId="PE",Name="Petty Cash Income"),
                new TransactionMode(TransactionId="BL",Name="Breakfast & Lunch"),
                new TransactionMode(TransactionId="TC",Name="Tea & Coffee"),
                new TransactionMode(TransactionId="OP",Name="Online Purhcase"),
                new TransactionMode(TransactionId="SU",Name="Suspense"),
                new TransactionMode(TransactionId="ST",Name="Stationary"),
                new TransactionMode(TransactionId="SC",Name="Short In Cash"),
                new TransactionMode(TransactionId="PU",Name="Puja Expenses"),

        };

            db.TransactionModes.AddRange(TransactionModes);
            count += db.SaveChanges();

            // Default Party Ledgers

            var LedgerGroup = new List<LedgerGroup>{
                new LedgerGroup{LedgerGroupId="NOPARTY",LedgerGroupName="No Party", Category=LedgerCategory.Others},
                new LedgerGroup{LedgerGroupId="CASH",LedgerGroupName="Cash", Category=LedgerCategory.Assets},
                new LedgerGroup{LedgerGroupId="BANK",LedgerGroupName="Bank", Category=LedgerCategory.Bank},
                new LedgerGroup{LedgerGroupId="CRD",LedgerGroupName="Credit", Category=LedgerCategory.Assets},
                new LedgerGroup{LedgerGroupId="DBT",LedgerGroupName="Debit", Category=LedgerCategory.Assets},
                new LedgerGroup{LedgerGroupId="SLY",LedgerGroupName="Salary", Category=LedgerCategory.Expenses},
                new LedgerGroup{LedgerGroupId="PUR",LedgerGroupName="Purchase", Category=LedgerCategory.Expenses},
                new LedgerGroup{LedgerGroupId="SAL",LedgerGroupName="Sales", Category=LedgerCategory.Expenses},
                new LedgerGroup{LedgerGroupId="INC",LedgerGroupName="Income", Category=LedgerCategory.Income},
                new LedgerGroup{LedgerGroupId="EXO",LedgerGroupName="Expense", Category=LedgerCategory.Expenses},
                new LedgerGroup{LedgerGroupId="OTH",LedgerGroupName="Others", Category=LedgerCategory.Others},
                new LedgerGroup{LedgerGroupId="IDINC",LedgerGroupName="Indirect Income", Category=LedgerCategory.Assets},
                new LedgerGroup{LedgerGroupId="IDEXP",LedgerGroupName="Indirect Expense", Category=LedgerCategory.Expense},

            };

            db.LedgerGroups.AddRange(LedgerGroup);
            count += db.SaveChanges();
            var partyLedgers = new List<Party>{
                new Party{PartyId="NOPARTY",PartyName="No Party", OpeningDate=defDate,
                ClosingBalance=0,OpeningBalance=0,Category=LedgerCategory.Others, LedgerGroupId="NOPARTY"},
                new Party{PartyId="TIE",PartyName="Telephone & Internet", OpeningDate=defDate,
                ClosingBalance=0,OpeningBalance=0,Category=LedgerCategory.Expense, LedgerGroupId="IDEXP"},
                new Party{PartyId="SNB",PartyName="Snacks & Beverages", OpeningDate=defDate,
                ClosingBalance=0,OpeningBalance=0,Category=LedgerCategory.Expense, LedgerGroupId="IDEXP"},
                new Party{PartyId="EB",PartyName="Eletricity Bill", OpeningDate=defDate,
                ClosingBalance=0,OpeningBalance=0,Category=LedgerCategory.Expense, LedgerGroupId="IDEXP"},
                new Party{PartyId="SNP",PartyName="Stationary & Printing", OpeningDate=defDate,
                ClosingBalance=0,OpeningBalance=0,Category=LedgerCategory.Expense, LedgerGroupId="IDEXP"},
                new Party{PartyId="ASAL",PartyName="Salary Adavances", OpeningDate=defDate,
                ClosingBalance=0,OpeningBalance=0,Category=LedgerCategory.Expenses, LedgerGroupId="SLY"},
                new Party{PartyId="FRC",PartyName="Frieght Charges", OpeningDate=defDate,
                ClosingBalance=0,OpeningBalance=0,Category=LedgerCategory.Expenses, LedgerGroupId="IDEXP"},

                //TODO: Need to add Party Ledger for basic accounting.
            };

            db.Parties.AddRange(partyLedgers);
            count += db.SaveChanges();

            if (userCreated)
            {
                return count;
            }
            else return -1;

        }
        private static RegisteredClient CreateAdminUser(ARDBContext db, ApplicationDbContext context, ClientInfo info, RegisteredClient client)
        {

            client.Owner = new Employee
            {
                EmployeeId = $"OWN/{Client.StartDate.Year}/0001",
                EmpId = 1,
                EntryStatus = EntryStatus.Added,
                JoiningDate = new DateTime(2015, 10, 1),
                IsActive = true,
                IsWorking = true,
                Category = EmpType.Owner,
                IsReadOnly = true,
                MarkedDeleted = false,
                Name = client.OwnerName,
                Gender = Gender.Male,
                DOB = new DateTime(1982, 07, 24),
                Title = "Mr.",
                City = client.City,
                State = client.State,
                MobileNo = client.Mobile,
                Country = client.Country,
                Email = client.Email,
                StreetName = client.Address,
                ZipCode = client.PiCode,
                StoreId = client.StoreCode,
                UserId = "AutoADMIN",
                FirstName = client.Owner.Split(' ')[0],
                LastName = client.Owner.Split(' ')[1],

            };

            db.Employees.Add(client.Owner);
            int cont = db.SaveChanges();

            client.Remarks += $"#Owner Employee  Created[EmpId:{client.Owner.EmployeeId}];";

            bool userCreated = false;
            var user = CreateUser();
            await _userStore.SetUserNameAsync(user, client.RegisterAdminUserName, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, info.Email, CancellationToken.None);

            user.FullName = "Admin User";
            user.StoreId = client.Stores[0].StoreId;
            user.EmployeeId = client.Owner.EmployeeId;

            user.StoreGroupId = client.StoreGroups[0].StoreGroupId;
            user.Approved = true;
            user.Permission = RolePermission.Owner;


            var result = await _userManager.CreateAsync(user, client.DefaultPassword);

            if (result.Succeeded)
            {
                //Do Conirmation here
                _logger.LogInformation("User created a new account with password.");
                var userId = await _userManager.GetUserIdAsync(user);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                if (_userManager.Options.SignIn.RequireConfirmedAccount)
                {
                    var result = await _userManager.ConfirmEmailAsync(user, code);
                    if (result.Succeeded)
                        userCreated = true;
                }
                else
                {
                    userCreated = true;
                }
                client.Remarks += $"#Admin User Created[U:{user.UserId}, P:{client.DefaultPassword}];";

            }

            if (userCreated)
            {
                var user = CreateUser();
                await _userStore.SetUserNameAsync(user, info.OwnerName.ToLower(), CancellationToken.None);
                await _emailStore.SetEmailAsync(user, info.Email, CancellationToken.None);

                user.FullName = info.OwnerName;
                user.StoreId = info.StoreCode;
                user.EmployeeId = client.Owner.EmployeeId;

                user.StoreGroupId = info.StoreCode;
                user.Approved = true;
                user.Permission = RolePermission.Owner;


                var result = await _userManager.CreateAsync(user, "Owner@123");

                if (result.Succeeded)
                {
                    //Do Conirmation here
                    _logger.LogInformation("User created a new account with password.");
                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        var result = await _userManager.ConfirmEmailAsync(user, code);
                        if (result.Succeeded)
                            userCreated = true;
                    }
                    else
                    {
                        userCreated = true;
                    }
                    client.Remarks += $"#Owner User Created[U:{user.UserId}, P:Owner@123];";
                }

            }
            return client;

        }
        private static RegisteredClient CreateStore(ARDBContext db, ApplicationDbContext context, ClientInfo info)
        {

            AppClient client = new AppClient
            {
                AppClientId = Guid.NewGuid(),
                ClientName = "Aadwika Fashion",
                ClientAddress = "Bhagalpur Road, Near TATA Showroom,Dumka",
                MobileNumber = "06434224461",
                City = "Dumka",
                StartDate = new DateTime(2024, 04, 01),
                EndDate = null
            };
            StoreGroup group = new StoreGroup
            {
                AppClientId = client.AppClientId,
                GroupName = "Addwika Fashion MBO",
                Remarks = "Convert to MBO",
                StoreGroupId = "MBO",

            };
            Store store = new Store
            {
                AppClientId = client.AppClientId,
                BeginDate = new DateTime(2024, 4, 1),
                City = "Dumka",
                Country = "India",
                EndDate = null,
                AppClient = null,
                GSTIN = "20AJHPA7396P1ZV",
                IsActive = true,
                MarkedDeleted = false,
                PanNo = "AJPHA7396P",
                State = "Jharkhand",
                StoreCode = "MBO001",
                StoreEmailId = "aadwikafashion.mbo@gmail.com",
                StoreGroup = group,
                StoreGroupId = "MBO",
                StoreId = "MBO",
                StoreManager = "Alok Kumar",
                StoreManagerContactNo = "",
                StoreName = "Aadwika Fashion",
                StorePhoneNumber = "06434224461",
                VatNo = "",
                ZipCode = "814101"

            };
            db.AppClients.Add(client);
            db.StoreGroups.Add(group);
            db.Stores.Add(store);

            int result = db.SaveChanges();
            return new RegisteredClient
            {
                Client = client,
                Groups = new List<StoreGroup> { group },
                Stores = new List<Store> { store },
                RegisterAdminUserName = "Admin",
                DefaultPassword = "Admin@1234"
            };
        }


        private static RegisteredClient CreateDefaultOptions(ARDBContext db, ApplicationDbContext context, RegisteredClient client)
        {

            DateTime defDate = client.StartDate ?? DateTime.Now;

            //Create Bank Name
            var banks = [ new Bank{BankId="SBI",Name="State Bank Of India"},
            new Bank{BankId="HDFC",Name="HDFC Bank"}, new Bank{BankId="ICICI",Name="ICICI Bank"},
            new Bank{BankId="AXIS",Name="Axis Bank"}, new Bank{BankId="KOTAK",Name="Kotak Mahindra Bank"},
            new Bank{BankId="BOB",Name="Bank Of Baroda"}, new Bank{BankId="PUNJAB",Name="Punjab National Bank"},
            new Bank{BankId="IDBI",Name="IDBI Bank"}, new Bank{BankId="FEDERAL",Name="Federal Bank"},
            new Bank{BankId="IDFC",Name="IDFC Bank"}, new Bank{BankId="INDIAN",Name="Indian Bank"},
            new Bank{BankId="CANARA",Name="Canara Bank"}, new Bank{BankId="RBL",Name="RBL Bank"},
            new Bank{BankId="DBS",Name="DBS Bank"},          new Bank{BankId="UNION",Name="Union Bank"},
            new Bank{BankId="CITI",Name="Citi Bank"},          new Bank{BankId="YES",Name="Yes Bank"},
            new Bank(BankId="OTHERS",Name="Others"), new Bank{BankId="HSBC",Name="HSBC Bank"}
            ];
            db.Banks.AddRange(banks);
            int count = db.SaveChanges();

            client.Remarks += $"#Created {count} Banks;";

            //TransactionMode

            var TransactionModes = new List<TransactionMode>
            {
                new TransactionMode(TransactionId="CI",TransactionName="Cash In"),
                new TransactionMode(TransactionId="CO",TransactionName="CashOut"),
                new TransactionMode(TransactionId="PE",TransactionName="Petty Cash Expenses"),
                new TransactionMode(TransactionId="AE",TransactionName="Amit Expense"),
                new TransactionMode(TransactionId="HE",TransactionName="Home Expense"),
                new TransactionMode(TransactionId="VE",TransactionName="Vehicle Expense"),
                new TransactionMode(TransactionId="TE",TransactionName="Telephone Expense"),
                new TransactionMode(TransactionId="ME",TransactionName="Miscellaneous Expense"),
                new TransactionMode(TransactionId="PE",TransactionName="Petty Cash Income"),
                new TransactionMode(TransactionId="BL",TransactionName="Breakfast & Lunch"),
                new TransactionMode(TransactionId="TC",TransactionName="Tea & Coffee"),
                new TransactionMode(TransactionId="OP",TransactionName="Online Purhcase"),
                new TransactionMode(TransactionId="SU",TransactionName="Suspense"),
                new TransactionMode(TransactionId="ST",TransactionName="Stationary"),
                new TransactionMode(TransactionId="SC",TransactionName="Short In Cash"),
                new TransactionMode(TransactionId="PU",TransactionName="Puja Expenses"),

        };

            db.TransactionModes.AddRange(TransactionModes);
            count += db.SaveChanges();

            client.Remarks += $"#Created {count} Transaction Modes;";

            // Default Party Ledgers

            var LedgerGroup = new List<LedgerGroup>{
                new LedgerGroup{LedgerGroupId="NOPARTY",LedgerGroupName="No Party", Category=LedgerCategory.Others},
                new LedgerGroup{LedgerGroupId="CASH",LedgerGroupName="Cash", Category=LedgerCategory.Assets},
                new LedgerGroup{LedgerGroupId="BANK",LedgerGroupName="Bank", Category=LedgerCategory.Bank},
                new LedgerGroup{LedgerGroupId="CRD",LedgerGroupName="Credit", Category=LedgerCategory.Assets},
                new LedgerGroup{LedgerGroupId="DBT",LedgerGroupName="Debit", Category=LedgerCategory.Assets},
                new LedgerGroup{LedgerGroupId="SLY",LedgerGroupName="Salary", Category=LedgerCategory.Expenses},
                new LedgerGroup{LedgerGroupId="PUR",LedgerGroupName="Purchase", Category=LedgerCategory.Expenses},
                new LedgerGroup{LedgerGroupId="SAL",LedgerGroupName="Sales", Category=LedgerCategory.Expenses},
                new LedgerGroup{LedgerGroupId="INC",LedgerGroupName="Income", Category=LedgerCategory.Income},
                new LedgerGroup{LedgerGroupId="EXO",LedgerGroupName="Expense", Category=LedgerCategory.Expenses},
                new LedgerGroup{LedgerGroupId="OTH",LedgerGroupName="Others", Category=LedgerCategory.Others},
                new LedgerGroup{LedgerGroupId="IDINC",LedgerGroupName="Indirect Income", Category=LedgerCategory.Assets},
                new LedgerGroup{LedgerGroupId="IDEXP",LedgerGroupName="Indirect Expense", Category=LedgerCategory.Expense},

            };

            db.LedgerGroups.AddRange(LedgerGroup);
            count += db.SaveChanges();

            client.Remarks += $"#Created {count} Ledger Groups;";

            var partyLedgers = new List<Party>{
                new Party{PartyId="NOPARTY",PartyName="No Party", OpeningDate=defDate,
                ClosingBalance=0,OpeningBalance=0,Category=LedgerCategory.Others, LedgerGroupId="NOPARTY"},
                new Party{PartyId="TIE",PartyName="Telephone & Internet", OpeningDate=defDate,
                ClosingBalance=0,OpeningBalance=0,Category=LedgerCategory.Expense, LedgerGroupId="IDEXP"},
                new Party{PartyId="SNB",PartyName="Snacks & Beverages", OpeningDate=defDate,
                ClosingBalance=0,OpeningBalance=0,Category=LedgerCategory.Expense, LedgerGroupId="IDEXP"},
                new Party{PartyId="EB",PartyName="Eletricity Bill", OpeningDate=defDate,
                ClosingBalance=0,OpeningBalance=0,Category=LedgerCategory.Expense, LedgerGroupId="IDEXP"},
                new Party{PartyId="SNP",PartyName="Stationary & Printing", OpeningDate=defDate,
                ClosingBalance=0,OpeningBalance=0,Category=LedgerCategory.Expense, LedgerGroupId="IDEXP"},
                new Party{PartyId="ASAL",PartyName="Salary Adavances", OpeningDate=defDate,
                ClosingBalance=0,OpeningBalance=0,Category=LedgerCategory.Expenses, LedgerGroupId="SLY"},
                new Party{PartyId="FRC",PartyName="Frieght Charges", OpeningDate=defDate,
                ClosingBalance=0,OpeningBalance=0,Category=LedgerCategory.Expenses, LedgerGroupId="IDEXP"},

                //TODO: Need to add Party Ledger for basic accounting.
            };

            db.Parties.AddRange(partyLedgers);
            count += db.SaveChanges();

            client.Remarks += $"#Created {count} Ledgers;";
            return client;

        }


        public static async Task<int> InstallDefaultClient(ARDBContext db, ApplicationDbContext context)
        {

            //Creating Default AppClient
            AppClient client = new AppClient
            {
                AppClientId = Guid.NewGuid(),
                ClientName = "Aadwika Fashion",
                ClientAddress = "Bhagalpur Road, Near TATA Showroom,Dumka",
                MobileNumber = "06434224461",
                City = "Dumka",
                StartDate = new DateTime(2024, 04, 01),
                ExpireDate = null

            };
            StoreGroup group = new StoreGroup
            {
                AppClientId = client.AppClientId,
                GroupName = "Addwika Fashion MBO",
                Remarks = "Convert to MBO",
                StoreGroupId = "MBO",

            };
            Store store = new Store
            {
                AppClientId = client.AppClientId,
                BeginDate = new DateTime(2024, 4, 1),
                City = "Dumka",
                Country = "India",
                EndDate = null,
                AppClient = null,
                GSTIN = "20AJHPA7396P1ZV",
                IsActive = true,
                MarkedDeleted = false,
                PanNo = "AJPHA7396P",
                State = "Jharkhand",
                StoreCode = "MBO001",
                StoreEmailId = "aadwikafashion.mbo@gmail.com",
                StoreGroup = group,
                StoreGroupId = "MBO",
                StoreId = "MBO",
                StoreManager = "Alok Kumar",
                StoreManagerContactNo = "",
                StoreName = "Aadwika Fashion",
                StorePhoneNumber = "06434224461",
                VatNo = "",
                ZipCode = "814101"

            };
            db.AppClients.Add(client);
            db.StoreGroups.Add(group);
            db.Stores.Add(store);

            Salesman salesman = new Salesman
            {
                EmployeeId = "SM",
                EntryStatus = EntryStatus.Added,
                IsActive = true,
                IsReadOnly = true,
                MarkedDeleted = false,
                Name = "Manager",
                SalesmanId = "MBO-2024-SM-1",
                StoreId = "MBO",
                UserId = "AutoADMIN"
            };
            db.Salesmen.Add(salesman);
            Employee emp = new Employee
            {
                EmployeeId = "OWN/2015/0001",
                EmpId = 1,
                //EntryStatus = EntryStatus.Added,
                JoiningDate = new DateTime(2015, 10, 1),

                IsWorking = true,
                Category = EmpType.Owner,
                //IsReadOnly = true,
                MarkedDeleted = false,

                Gender = Gender.Male,
                DOB = new DateTime(1982, 07, 24),
                Title = "Mr.",
                City = "Dumka",
                State = "Jharkhand",
                //MobileNo = "9334799099",
                Country = "India",
                //Email = "amitkumar@akslabs.in",
                StreetName = "Police Line Road",
                ZipCode = "814101",
                StoreId = "MBO",
                //UserId = "AutoADMIN",
                FirstName = "Amit",
                LastName = "Kumar",

            };

            db.Employees.Add(emp);
            int x = db.SaveChanges();

            int count = InstallDefaultOptions(db, context, new DateTime(2024, 4, 1), store.StoreId, group.StoreGroupId, salesman.EmployeeId);
            bool userCreated = false;
            if (count > 0)
            {

                //Create Default Admin User

                var user = CreateUser();
                await _userStore.SetUserNameAsync(user, "AmitKumar", CancellationToken.None);
                await _emailStore.SetEmailAsync(user, "amitkumar@akslabs.in", CancellationToken.None);

                user.FullName = "Amit Kumar";
                user.StoreId = "MBO";
                user.EmployeeId = "OWN/2015/0001";

                user.StoreGroupId = "MBO";
                user.Approved = true; user.Permission = RolePermission.Owner;


                var result = await _userManager.CreateAsync(user, "Dumka@123");

                if (result.Succeeded)
                {
                    //Do Conirmation here
                    _logger.LogInformation("User created a new account with password.");
                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        var result = await _userManager.ConfirmEmailAsync(user, code);
                        if (result.Succeeded)
                            userCreated = true;
                    }
                    else
                    {
                        userCreated = true;
                    }
                }

                //TODO: Add default Bank Account, POS Machine, Cashier, etc.

                BankAccount bankAccount = new BankAccount
                {
                    AccountNumber = "SBI CC",
                    AccountHolderName = "Amit Kumar",
                    BankId = "SBI",
                    DefaultBank = true,
                    SharedAccount = true,
                    IsActive = true,
                    AccountType = AccountType.Current,
                    BranchName = "Lic Colleny",
                    IFSC = "SBI000000",
                    OpeningBalance = 0,
                    CurrentBalance = 0,
                    OpeningDate = DateTime.Today,
                    MarkedDeleted = false,
                   
                    StoreId = "MBO",
                    StoreGroupId = "MBO",
                    AppClientId = client.AppClientId,


                };

                db.BankAccounts.Add(bankAccount);

                count += db.SaveChanges();
            }

            if (userCreated)
            {
                if (count > 0 && x > 0)
                    return count + x;
                else return -9;
            }
            else return -99;

        }
        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }

        private async Task<bool> ConfirmEmailAsync(ApplicationUser user, string code)
        {
            //code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            return result.Succeeded ? true : false;
        }

    }//end of class
}

