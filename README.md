# Metro_Ticketing_Backend

##Project Structure:

=> A class library with the name DOMAIN for our models, dto.

=> A class library with the name INFASTRUCTURE for interfaces such as unit of work and other common general operations that are gonna use in other layers.

=> A class library with the name DAL to communicate with the database.

=> a class library with the name IOC to handle our dependency injections in one layer.

=> A class library with the name BL to implement our business rules.

=> A WEB API .net core to implement our API'S

##IMPLEMENT OF DOMAIN LAYER:
We have 8 tables:

=>Users:
=>Train:
=>Seat:
=>Passenger:
=>Booking:
=>Ticket:
=>Bank Credential:
=>Transaction:

![image](https://user-images.githubusercontent.com/78077360/227708827-36ab6d18-6638-4f1f-9f73-1c671def64b0.png)

##IMPLEMENT OF DAL LAYER:

Connect to Database:
Now we want to connect to the database. The DAL Layer should be responsible for this one.
Before starting we should install the necessary packages. Install these packages on DAL Project:

=> Microsoft.EntityFrameworkCore
=> Microsoft.EntityFrameworkCore.Design
=> Microsoft.EntityFrameworkCore.SqlServer
=> Microsoft.EntityFrameworkCore.Tools
=> AutoMapper.
=> AutoMapper.Extensions.Microsoft.DependencyInjection.

As we know the database context gets the connection string from the end layer. in this project, our context gets the database connection string from the _Api_ layer. so we need to define the database connection string in the file _appsettings.json_ in the _Api_ layer. like this:

"ConnectionStrings": {
"MetroTicketingDbContext": "Server=DESKTOP-MQ97L1D\\SQLEXPRESS;Database=MetroTicketingDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;"
},

Now we should connect our context to the database. For this one, we should do it in the IOC layer that injects the services(here, the IoC layer).
For this, you need to install the package:
=> Microsoft.Extensions.DependencyInjection.Abstractions.
=> Microsoft.Extensions.Configuration.Abstractions.
Then we create a class with the name DbConfig in the IOC PROJECT and use the EF core service to connect our database context to the database. like this:

public static class DbConfig
{
public static IServiceCollection AddDatabaseConfig(this IServiceCollection services, IConfiguration configuration)
{
services.AddDbContext<MetroTicketingDbContext>(
options => options.UseSqlServer(configuration.GetConnectionString("MetroTicketingDbContext"))
);

            return services;
        }

    }

At the next step you should inject this config in the end layer with the path: Api/Program.cs like this:
builder.Services.AddDatabaseConfig(configuration);

Now we need to create a database and tables by EF. Before using migration you should install:

=>Microsoft.EntityFrameworkCore.Design on the Api layer because it's needed.

Now you can go to Package Manager Console and write the first add migration code like this: Add-Migrations InitializeDb.

##IMPLEMENT OF UNIT OF WORK:

We use the UnitOfWork pattern to work with data such as (get, write, update or delete).
So since the UnitOfWork has 2 parts, the first part is Interface and the second part is Implementation.
We put the Interface in the Infrastructure layer and implement them in the DAL layer.

In the Infrastructure layer create a folder with the name IUnitOfWork then create 2 interfaces one with the name IGenericRepository and the other with the name IUnitOfWork.

In IGenericRepository you should define all crud methods that you want to use in the project such as (getById, getAll, Insert, ...) and this class is the generic type of T that T is the name of our table.
It means that the IGenericRepository can be a polymorphism of any model and your methods can operate for any table of database.
In IUnitOfWork you should declare an instance of IGenericRepository per table of the database just like this:

IGenericRepository<User> UserRepository { get; }
IGenericRepository<Booking> BookingRepository { get; }
IGenericRepository<Passenger> PassengerRepository { get; }
IGenericRepository<Ticket> TicketRepository { get; }
IGenericRepository<BankCredential> BankCredentialRepository { get; }
IGenericRepository<Seat> SeatRepository { get; }
IGenericRepository<Train> TrainRepository { get; }
IGenericRepository<Transaction> TransactionRepository { get; }
void Save();
Task SaveAsync();

Now it's time for implementation. Go to the DAL layer and create a folder with the name UnitOfWork then create 2 classes with the name GenericRepository and UnitOfWork then implement the interfaces that you made in the Infrastructure layer.
Don't forget that the IUnitOfWork interface and UnitOfWork class both should inherit from IDisposable so when the UnitOfWork is finished with the database it can free unmanaged resources.

At the last step you should inject the UnitOfWork in the IOC layer and then in the Api layer. so Create a class with the name UnitOfWorkConfig in the IoC layer and inject the UnitOfWork like this:

    public static class UnitOfWorkConfig
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }

Then inject this class in the Api layer like this:
builder.Services.AddUnitOfWork(configuration);

##IMPLEMENT OF BL LAYER:
Now it's time to implement the BL layer according to our business rules and our scenarios for CRUD operations. Note: it's not good to return the database model to api, it's better to convert your database model to dto (data transfer object). It's better to have one or more dtos per scenario.

The first step is installing Automapper. why? to convert database model to dto. Since the working with data is DAL layer duty.
So we put it in DAL layer then install these packages in DAL layer:
=> AutoMapper and
=> AutoMapper.Extensions.Microsoft.DependencyInjection by the nuget package manager.
=> Microsoft.EntityFrameworkCore.

After installing Automaooer You need to set some things.

First, create a folder with the name AutomapperProfile in the DAL layer then create a class with the name MappingProfile.
In this class you must declare what model map to what dto or reverse.
Second you should inject Automapper and your MappingProfile class in the IOC layer as usual.
So create a class with the name AutomapperConfig in the IoC layer and inject Automapper like this:

public static class AutoMapperConfig
{
public static IServiceCollection AddAutomapper(this IServiceCollection services, IConfiguration configuration)
{
var mapperConfig = new MapperConfiguration(mc =>
{
mc.AddProfile(new MappingProfile());
});

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }

Inject this method in the Api layer as we did in previous steps:
builder.Services.AddAutomapper(configuration);

Create a class with the name BusinessConfig:

    public static class BusinessConfig
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<UserBusiness>();
            services.AddScoped<TrainBusiness>();
            services.AddScoped<SeatBusiness>();
            services.AddScoped<PassengerBusiness>();
            services.AddScoped<BankCredentialBusiness>();
            services.AddScoped<BookingBusiness>();
            services.AddScoped<TicketBusiness>();
            services.AddScoped<TransactionBusiness>();
            return services;
        }
    }

Inject this method in the Api layer as we did in previous steps:
builder.Services.AddBusiness(configuration);

##IMPLEMENT OF API LAYER:##

Project Dpendency forlayers:
##Metro.Ticketing.API:
=>Metro.Ticketing.DAL.
=>Metro.Ticketing.IOC.

##Metro.Ticketing.BL:
=>Metro.Ticketing.Infrastructure.

##Metro.Ticketing.DAL:
=>Metro.Ticketing.Infrastructure.
=>Metro.Ticketing.Domain.

##Metro.Ticketing.Infrastructure:
=>Metro.Ticketing.Domain.

##Metro.Ticketing.IOC:
=>Metro.Ticketing.BL.
=>Metro.Ticketing.DAL
