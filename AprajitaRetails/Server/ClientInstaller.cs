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

    }
    public class ClientInstaller
    {
        public static void Install(ARDBContext db, ApplicationDBContext context.ClientInfo info)
        {
            //InstallClient();
        }

        public static int InstallDefaultClient(ARDBContext db, ApplicationDBContext context)
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
                EndDate = null
            }
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
            int x = db.SaveChanges();

            int count = InstallDefaultOptions(db, null, store.StoreId, group.StoreGroupId, salesman.EmployeeId);
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

                //TODO: Add default Bank Account, POS Machine etc
            }

            if(userCreated){
                if(count > 0 && x>0)
                return count+x;
                else return-9; 
            }
            else return -99;

        }

        public static int InstallDefaultOptions(ARDBContext db, ApplicationDBContext context, DateTime? defDate, string storeid = "", string groupid = "", string eid = "")
        {


             defDate=defDate ?? DateTime.Now;   
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
                new TransactionMode(TransactionModeId="CI",Name="Cash In"),
                new TransactionMode(TransactionModeId="CO",Name="CashOut"),
                new TransactionMode(TransactionModeId="PE",Name="Petty Cash Expenses"),
                new TransactionMode(TransactionModeId="AE",Name="Amit Expense"),
                new TransactionMode(TransactionModeId="HE",Name="Home Expense"),
                new TransactionMode(TransactionModeId="VE",Name="Vehicle Expense"),
                new TransactionMode(TransactionModeId="TE",Name="Telephone Expense"),
                new TransactionMode(TransactionModeId="ME",Name="Miscellaneous Expense"),
                new TransactionMode(TransactionModeId="PE",Name="Petty Cash Income"),
                new TransactionMode(TransactionModeId="BL",Name="Breakfast & Lunch"),
                new TransactionMode(TransactionModeId="TC",Name="Tea & Coffee"),
                new TransactionMode(TransactionModeId="OP",Name="Online Purhcase"),
                new TransactionMode(TransactionModeId="SU",Name="Suspense"),
                new TransactionMode(TransactionModeId="ST",Name="Stationary"),
                new TransactionMode(TransactionModeId="SC",Name="Short In Cash"),
                new TransactionMode(TransactionModeId="PU",Name="Puja Expenses"),

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

            }

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
            }

            db.Parties.AddRange(partyLedgers);
            count += db.SaveChanges();




            if (userCreated)
            {
                return count;
            }
            else return -1;

        }


    }