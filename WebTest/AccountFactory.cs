using Infrastructure;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases;

namespace WebTest
{
    public class AccountFactory
    {
        public static IAccountRepository CreateAccountRepository()
        {
            var options = new DbContextOptionsBuilder<SocialNetworkContext>()
                .UseInMemoryDatabase(databaseName: "SocialNetwork")
                .Options;
            return new AccountRepository(new SocialNetworkContext(options));
        }
    }
}
