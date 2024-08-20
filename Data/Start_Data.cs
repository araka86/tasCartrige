using System;
using System.Collections.Generic;
using System.Data.Entity;
namespace CartrigeAltstar.Model
{
    class ContexAltstarInit : CreateDatabaseIfNotExists<ContexAltstar>
    {




        protected override void Seed(ContexAltstar context)
        {


            Department sb1 = new Department
            {

                Name = " Сто Бориспольская",
                Address = "Киев, ул. Бориспольсякая 7"


            };
            Department sb2 = new Department
            {

                Name = "СТО Киев Академгородок",
                Address = "Киев, ул. Степанченко, 5-4"


            };
            Department sb3 = new Department
            {

                Name = "СТО Киев Окружная",
                Address = "Киев, ул. Большая Окружная, 4Г"


            };
            Department sb4 = new Department
            {

                Name = "СТО Киев Выдубичи",
                Address = "Киев, ул. Будиндустрии, 6",



            };
            Department sb5 = new Department
            {

                Name = "СТО Киев Жуляны Авторынок",
                Address = "Киев, ул. Садовая 70А/110"


            };
            Department sb6 = new Department
            {

                Name = "СТО Киев Голосеево",
                Address = "Киев ул. Голосеевская, 9"


            };
            Department sb7 = new Department
            {

                Name = "СТО Киев Подол",
                Address = "Киев ул. Новоконстантиновская 1В (Бокс 194, 195)"


            };
            Department sb8 = new Department
            {

                Name = "СТО Вишневое Центр",
                Address = "г. Вишневое, ул. Киевская, 1"


            };
            Department sb9 = new Department
            {

                Name = "СТО Бровары Центр",
                Address = "Бровары, ул. Киевская, 227/1"


            };
            Department sb10 = new Department
            {

                Name = "СТО Бровары Окружная",
                Address = "Бровары ул.Броварської сотні, 43 (ул. Чкалова)"


            };
            Department sb11 = new Department
            {

                Name = "Мастерская АЛЬТ-СТАР «Тиса» Окружная",
                Address = "Киев ул. Большая Кольцевая, 4Б"


            };
            Department sb12 = new Department
            {

                Name = "Мастерская Киев «Жуляны» Авторынок",
                Address = "Киев ул.Садовая, 70-А/110, п.176"


            };
            Department sb13 = new Department
            {

                Name = "Мастерская Киев «Перова» Авторынок",
                Address = "Киев ул.Перова, 19, павильон 6-А"


            };
            Department sb14 = new Department
            {

                Name = "Мастерская Альт Стар – Киев Пуховская",
                Address = "Киев, ул. Пуховская 2а"


            };
            Department sb15 = new Department
            {

                Name = "СТО Киев «Вереснева»",
                Address = "Киев ул. Вереснева 24"


            };
            Department sb16 = new Department
            {

                Name = "Бухгалтерия 275каб",
                Address = "Киев ул. Бориспольская 7, 2ет"


            };
            Department sb17 = new Department
            {

                Name = "279",
                Address = "Киев ул. Бориспольская 7, 2ет"

            };
            context.Departments.AddRange(new List<Department> { sb1, sb2, sb3, sb4, sb5, sb6, sb7, sb8, sb9, sb10, sb11, sb12, sb13, sb14, sb15, sb16 });


            //Cartrige ct1 = new Cartrige
            //{
            //    ModelCartrige = "ТК-3400",
            //    ArticleCartrige = "A_ТК-3400",
            //    CountCartrige = 11


            //};
            //Cartrige ct2 = new Cartrige
            //{
            //    ModelCartrige = "ТК-3160",
            //    ArticleCartrige = "A_ТК-3160",
            //    CountCartrige = 16

            //};
            //Cartrige ct3 = new Cartrige
            //{
            //    ModelCartrige = "ТК-3060",
            //    ArticleCartrige = "A_ТК-3060",
            //    CountCartrige = 10

            //};
            //Cartrige ct4= new Cartrige
            //{
            //    ModelCartrige = "ТК-3190",
            //    ArticleCartrige = "A_ТК-3190",
            //    CountCartrige = 3

            //};
            //Cartrige ct5 = new Cartrige
            //{
            //    ModelCartrige = "ТК-3100",
            //    ArticleCartrige = "A_ТК-3100",
            //    CountCartrige = 14

            //};
            //Cartrige ct6 = new Cartrige
            //{
            //    ModelCartrige = "ТК-1150",
            //    ArticleCartrige = "A_ТК-1150",
            //    CountCartrige = 1


            //};
            //Cartrige ct7 = new Cartrige
            //{
            //    ModelCartrige = "ТК-3130",
            //    ArticleCartrige = "A_ТК-3130",
            //    CountCartrige = 0


            //};

            //context.Cartriges.AddRange(new List<Cartrige> { ct1, ct2, ct3,ct4,ct5,ct6,ct7 });



            var cartriges = new List<Cartrige>
                {
                    new Cartrige { ModelCartrige = "ТК-3400", ArticleCartrige = "A_ТК-3400", CountCartrige = 11  },
                    new Cartrige { ModelCartrige = "ТК-3160", ArticleCartrige = "A_ТК-3160", CountCartrige = 16 },
                    new Cartrige { ModelCartrige = "ТК-3060", ArticleCartrige = "A_ТК-3060", CountCartrige = 10},
                    new Cartrige { ModelCartrige = "ТК-3190", ArticleCartrige = "A_ТК-3190", CountCartrige = 3 },
                    new Cartrige { ModelCartrige = "ТК-3100", ArticleCartrige = "A_ТК-3100", CountCartrige = 14 },
                    new Cartrige { ModelCartrige = "ТК-1150", ArticleCartrige = "A_ТК-1150", CountCartrige = 1},
                    new Cartrige { ModelCartrige = "ТК-3130", ArticleCartrige = "A_ТК-3130", CountCartrige = 0}
                };

            // Adding Cartrige objects to the context
            context.Cartriges.AddRange(cartriges);

            // Saving changes to the database to get the Ids for Cartrige objects
            context.SaveChanges();
            var startAdataLocations = new List<Cartrigelolocation>
            {
                new Cartrigelolocation{ Cartrige ="ТК-3400", Status= "+", CountCartige=11, Data = DateTime.Now.AddDays(-5) },
                new Cartrigelolocation{ Cartrige ="ТК-3160", Status= "+", CountCartige=16, Data = DateTime.Now.AddDays(-5) },
                new Cartrigelolocation{ Cartrige ="ТК-3190", Status= "+", CountCartige=10, Data = DateTime.Now.AddDays(-5) },
                new Cartrigelolocation{ Cartrige ="ТК-3400", Status= "+", CountCartige=3, Data = DateTime.Now.AddDays(-5) },
                new Cartrigelolocation{ Cartrige ="ТК-3100", Status= "+", CountCartige=14, Data = DateTime.Now.AddDays(-5) },
                new Cartrigelolocation{ Cartrige ="ТК-1150", Status= "+", CountCartige=1, Data = DateTime.Now.AddDays(-5) },
                new Cartrigelolocation{ Cartrige ="ТК-3130", Status= "+", CountCartige=0, Data = DateTime.Now.AddDays(-5) }
            };
            context.Cartrigelolocations.AddRange(startAdataLocations);
            context.SaveChanges();


            // Creating CountCartige objects with the foreign key set
            var countCartiges = new List<CountCartige>
                {
                    new CountCartige { CartrigeId = cartriges[0].Id, ModelCartrige = cartriges[0].ModelCartrige, CountCartrige = cartriges[0].CountCartrige, purchase_date = cartriges[0].purchase_date },
                    new CountCartige { CartrigeId = cartriges[1].Id, ModelCartrige = cartriges[1].ModelCartrige, CountCartrige = cartriges[1].CountCartrige, purchase_date = cartriges[1].purchase_date },
                    new CountCartige { CartrigeId = cartriges[2].Id, ModelCartrige = cartriges[2].ModelCartrige, CountCartrige = cartriges[2].CountCartrige, purchase_date = cartriges[2].purchase_date },
                    new CountCartige { CartrigeId = cartriges[3].Id, ModelCartrige = cartriges[3].ModelCartrige, CountCartrige = cartriges[3].CountCartrige, purchase_date = cartriges[3].purchase_date },
                    new CountCartige { CartrigeId = cartriges[4].Id, ModelCartrige = cartriges[4].ModelCartrige, CountCartrige = cartriges[4].CountCartrige, purchase_date = cartriges[4].purchase_date },
                    new CountCartige { CartrigeId = cartriges[5].Id, ModelCartrige = cartriges[5].ModelCartrige, CountCartrige = cartriges[5].CountCartrige, purchase_date = cartriges[5].purchase_date },
                    new CountCartige { CartrigeId = cartriges[6].Id, ModelCartrige = cartriges[6].ModelCartrige, CountCartrige = cartriges[6].CountCartrige, purchase_date = cartriges[6].purchase_date }
                };

            // Adding CountCartige objects to the context
            context.CountCartiges.AddRange(countCartiges);

            // Saving changes to the database
            context.SaveChanges();

            Printer pr1 = new Printer
            {
                
                ModelPrinter = "Samsung 106A",
                Article = "P0KV",
              //  CartrigePk = ct3,
                Department = sb4


            };
            Printer pr2 = new Printer
            {

                ModelPrinter = "Canon MF3010 V4",
                Article = "P001",
             //   CartrigePk = ct1,
                Department = sb1

            };
            Printer pr3 = new Printer
            {
               
                ModelPrinter = "Canon MF3010 V4",
                Article = "P883",
             //   CartrigePk = ct2,
                Department = sb1

            };

            context.Printers.AddRange(new List<Printer> { pr1, pr2, pr3 });
           


            Compatibility cp = new Compatibility
            {
               
              //  CartrigePK = ct3,
                Department = sb4

            };
            context.Compatibilities.Add(cp);
      

            User user = new User()
            {
                FirstName="Admin",
                LasttName="Admin",
                LoginId = "12345",
                UniqId = 1234567890,
                Role="SuperAdmin",
                Password="12345"
            };
            context.Users.Add(user);
            context.SaveChanges();






            ////another logig

            // Инициализация начальных данных
            var models = new List<CartrigeModel>
        {
            new CartrigeModel { ModelName = "А3160" },
            new CartrigeModel { ModelName = "Б2160" },
            new CartrigeModel { ModelName = "С1160" }
        };
            models.ForEach(m => context.CartrigeModels.Add(m));
            context.SaveChanges();

            var purchases = new List<CartrigePurchase>
        {
            new CartrigePurchase { ModelId = models[0].Id, PurchaseDate = new DateTime(2024, 7, 23), Quantity = 16 },
            new CartrigePurchase { ModelId = models[1].Id, PurchaseDate = new DateTime(2024, 7, 23), Quantity = 20 },
            new CartrigePurchase { ModelId = models[2].Id, PurchaseDate = new DateTime(2024, 7, 23), Quantity = 30 }
        };
            purchases.ForEach(p => context.CartrigePurchases.Add(p));
            context.SaveChanges();

            var issues = new List<CartrigeIssue>
        {
            new CartrigeIssue { ModelId = models[0].Id, IssueDate = new DateTime(2024, 7, 24), Quantity = 2, Department = "IT" },
            new CartrigeIssue { ModelId = models[0].Id, IssueDate = new DateTime(2024, 7, 25), Quantity = 4, Department = "HR" },
            new CartrigeIssue { ModelId = models[1].Id, IssueDate = new DateTime(2024, 7, 24), Quantity = 5, Department = "Finance" },
            new CartrigeIssue { ModelId = models[2].Id, IssueDate = new DateTime(2024, 7, 25), Quantity = 3, Department = "Operations" }
        };
            issues.ForEach(i => context.CartrigeIssues.Add(i));
            context.SaveChanges();

            base.Seed(context);


        }


    }
}
