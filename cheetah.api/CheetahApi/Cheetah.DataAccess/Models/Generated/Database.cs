



















// This file was automatically generated by the PetaPoco T4 Template
// Do not make changes directly to this file - edit the template instead
// 
// The following connection settings were used to generate this file
// 
//     Connection String Name: `CheetahPocoModel`
//     Provider:               `System.Data.SqlClient`
//     Connection String:      `Data Source=(localdb)\ProjectsV12;Initial Catalog=Cheetah;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False`
//     Schema:                 ``
//     Include Views:          `False`



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace Cheetah.DataAccess.Models
{

	public partial class CheetahPocoModelDB : Database
	{
		public CheetahPocoModelDB() 
			: base("CheetahPocoModel")
		{
			CommonConstruct();
		}

		public CheetahPocoModelDB(string connectionStringName) 
			: base(connectionStringName)
		{
			CommonConstruct();
		}
		
		partial void CommonConstruct();
		
		public interface IFactory
		{
			CheetahPocoModelDB GetInstance();
		}
		
		public static IFactory Factory { get; set; }
        public static CheetahPocoModelDB GetInstance()
        {
			if (_instance!=null)
				return _instance;
				
			if (Factory!=null)
				return Factory.GetInstance();
			else
				return new CheetahPocoModelDB();
        }

		[ThreadStatic] static CheetahPocoModelDB _instance;
		
		public override void OnBeginTransaction()
		{
			if (_instance==null)
				_instance=this;
		}
		
		public override void OnEndTransaction()
		{
			if (_instance==this)
				_instance=null;
		}
        

		public class Record<T> where T:new()
		{
			public static CheetahPocoModelDB repo { get { return CheetahPocoModelDB.GetInstance(); } }
			public bool IsNew() { return repo.IsNew(this); }
			public object Insert() { return repo.Insert(this); }

			public void Save() { repo.Save(this); }
			public int Update() { return repo.Update(this); }

			public int Update(IEnumerable<string> columns) { return repo.Update(this, columns); }
			public static int Update(string sql, params object[] args) { return repo.Update<T>(sql, args); }
			public static int Update(Sql sql) { return repo.Update<T>(sql); }
			public int Delete() { return repo.Delete(this); }
			public static int Delete(string sql, params object[] args) { return repo.Delete<T>(sql, args); }
			public static int Delete(Sql sql) { return repo.Delete<T>(sql); }
			public static int Delete(object primaryKey) { return repo.Delete<T>(primaryKey); }
			public static bool Exists(object primaryKey) { return repo.Exists<T>(primaryKey); }
			public static bool Exists(string sql, params object[] args) { return repo.Exists<T>(sql, args); }
			public static T SingleOrDefault(object primaryKey) { return repo.SingleOrDefault<T>(primaryKey); }
			public static T SingleOrDefault(string sql, params object[] args) { return repo.SingleOrDefault<T>(sql, args); }
			public static T SingleOrDefault(Sql sql) { return repo.SingleOrDefault<T>(sql); }
			public static T FirstOrDefault(string sql, params object[] args) { return repo.FirstOrDefault<T>(sql, args); }
			public static T FirstOrDefault(Sql sql) { return repo.FirstOrDefault<T>(sql); }
			public static T Single(object primaryKey) { return repo.Single<T>(primaryKey); }
			public static T Single(string sql, params object[] args) { return repo.Single<T>(sql, args); }
			public static T Single(Sql sql) { return repo.Single<T>(sql); }
			public static T First(string sql, params object[] args) { return repo.First<T>(sql, args); }
			public static T First(Sql sql) { return repo.First<T>(sql); }
			public static List<T> Fetch(string sql, params object[] args) { return repo.Fetch<T>(sql, args); }
			public static List<T> Fetch(Sql sql) { return repo.Fetch<T>(sql); }
			public static List<T> Fetch(long page, long itemsPerPage, string sql, params object[] args) { return repo.Fetch<T>(page, itemsPerPage, sql, args); }
			public static List<T> Fetch(long page, long itemsPerPage, Sql sql) { return repo.Fetch<T>(page, itemsPerPage, sql); }
			public static List<T> SkipTake(long skip, long take, string sql, params object[] args) { return repo.SkipTake<T>(skip, take, sql, args); }
			public static List<T> SkipTake(long skip, long take, Sql sql) { return repo.SkipTake<T>(skip, take, sql); }
			public static Page<T> Page(long page, long itemsPerPage, string sql, params object[] args) { return repo.Page<T>(page, itemsPerPage, sql, args); }
			public static Page<T> Page(long page, long itemsPerPage, Sql sql) { return repo.Page<T>(page, itemsPerPage, sql); }
			public static IEnumerable<T> Query(string sql, params object[] args) { return repo.Query<T>(sql, args); }
			public static IEnumerable<T> Query(Sql sql) { return repo.Query<T>(sql); }

		}

	}
	



    
	[TableName("Projects")]


	[PrimaryKey("Id")]



	[ExplicitColumns]
    public partial class Project : CheetahPocoModelDB.Record<Project>  
    {



		[Column] public int Id { get; set; }





		[Column] public string Name { get; set; }





		[Column] public string Description { get; set; }





		[Column] public string Label { get; set; }





		[Column] public DateTime CreatedAt { get; set; }





		[Column] public Guid CreatedBy { get; set; }





		[Column] public DateTime LastUpdatedAt { get; set; }





		[Column] public Guid LastUpdatedBy { get; set; }



	}

    
	[TableName("Corporations")]


	[PrimaryKey("Id")]



	[ExplicitColumns]
    public partial class Corporation : CheetahPocoModelDB.Record<Corporation>  
    {



		[Column] public int Id { get; set; }





		[Column] public string Name { get; set; }





		[Column] public string Description { get; set; }





		[Column] public DateTime CreatedAt { get; set; }





		[Column] public Guid CreatedBy { get; set; }





		[Column] public DateTime LastUpdatedAt { get; set; }





		[Column] public Guid LastUpdatedBy { get; set; }





		[Column] public int AddressId { get; set; }



	}

    
	[TableName("Addresses")]


	[PrimaryKey("Id")]



	[ExplicitColumns]
    public partial class Address : CheetahPocoModelDB.Record<Address>  
    {



		[Column] public int Id { get; set; }





		[Column] public string Street { get; set; }





		[Column] public string City { get; set; }





		[Column] public string ZipCode { get; set; }





		[Column] public string Country { get; set; }





		[Column] public string CountryCode { get; set; }





		[Column] public DateTime CreatedAt { get; set; }





		[Column] public Guid CratedBy { get; set; }





		[Column] public DateTime LastUpdatedAt { get; set; }





		[Column] public Guid LastUpdatedBy { get; set; }



	}

    
	[TableName("Teams")]


	[PrimaryKey("Id")]



	[ExplicitColumns]
    public partial class Team : CheetahPocoModelDB.Record<Team>  
    {



		[Column] public int Id { get; set; }





		[Column] public string Name { get; set; }





		[Column] public string Description { get; set; }





		[Column] public int OrganizationId { get; set; }





		[Column] public DateTime CreatedAt { get; set; }





		[Column] public Guid CreatedBy { get; set; }





		[Column] public DateTime LastUpdatedAt { get; set; }





		[Column] public Guid LastUpdatedBy { get; set; }



	}

    
	[TableName("Userstories")]


	[PrimaryKey("Id")]



	[ExplicitColumns]
    public partial class Userstory : CheetahPocoModelDB.Record<Userstory>  
    {



		[Column] public int Id { get; set; }





		[Column] public int Identity { get; set; }





		[Column] public string Story { get; set; }





		[Column] public string Risks { get; set; }





		[Column] public string AcceptCriterias { get; set; }





		[Column] public DateTime CreatedAt { get; set; }





		[Column] public Guid CreatedBy { get; set; }





		[Column] public DateTime LastUpdatedAt { get; set; }





		[Column] public Guid LastUpdatedBy { get; set; }





		[Column] public int? SprintId { get; set; }



	}

    
	[TableName("Organizations")]


	[PrimaryKey("Id")]



	[ExplicitColumns]
    public partial class Organization : CheetahPocoModelDB.Record<Organization>  
    {



		[Column] public int Id { get; set; }





		[Column] public string Name { get; set; }





		[Column] public string Description { get; set; }





		[Column] public int CorporationId { get; set; }





		[Column] public DateTime CreatedAt { get; set; }





		[Column] public Guid CreatedBy { get; set; }





		[Column] public DateTime LastUpdatedAt { get; set; }





		[Column] public Guid LastUpdatedBy { get; set; }



	}

    
	[TableName("Features")]


	[PrimaryKey("Id")]



	[ExplicitColumns]
    public partial class Feature : CheetahPocoModelDB.Record<Feature>  
    {



		[Column] public int Id { get; set; }





		[Column] public string Label { get; set; }





		[Column] public string Name { get; set; }





		[Column] public string Description { get; set; }





		[Column] public DateTime CreatedAt { get; set; }





		[Column] public Guid CreatedBy { get; set; }





		[Column] public DateTime LastUpdatedAt { get; set; }





		[Column] public Guid LastUpdatedBy { get; set; }



	}

    
	[TableName("Tasks")]


	[PrimaryKey("Id")]



	[ExplicitColumns]
    public partial class Task : CheetahPocoModelDB.Record<Task>  
    {



		[Column] public int Id { get; set; }





		[Column] public int Identity { get; set; }





		[Column] public string Summary { get; set; }





		[Column] public string Description { get; set; }





		[Column] public int Estimate { get; set; }





		[Column] public int Remaining { get; set; }





		[Column] public DateTime CreatedAt { get; set; }





		[Column] public Guid CreatedBy { get; set; }





		[Column] public DateTime LastUpdatedAt { get; set; }





		[Column] public Guid LastUpdatedBy { get; set; }



	}

    
	[TableName("SprintReviews")]


	[PrimaryKey("Id")]



	[ExplicitColumns]
    public partial class SprintReview : CheetahPocoModelDB.Record<SprintReview>  
    {



		[Column] public int Id { get; set; }





		[Column] public string Review { get; set; }





		[Column] public DateTime CreatedAt { get; set; }





		[Column] public Guid CreatedBy { get; set; }





		[Column] public DateTime LastUpdatedAt { get; set; }





		[Column] public Guid LastUpdatedBy { get; set; }



	}

    
	[TableName("SprintRetrospectives")]


	[PrimaryKey("Id", autoIncrement=false)]

	[ExplicitColumns]
    public partial class SprintRetrospective : CheetahPocoModelDB.Record<SprintRetrospective>  
    {



		[Column] public int Id { get; set; }





		[Column] public string Headline { get; set; }





		[Column] public int SprintId { get; set; }





		[Column] public DateTime CreatedAt { get; set; }





		[Column] public Guid CreatedBy { get; set; }





		[Column] public DateTime LastUpdatedAt { get; set; }





		[Column] public Guid LastUpdatedBy { get; set; }



	}

    
	[TableName("SprintRetrospectiveItems")]


	[PrimaryKey("Id", autoIncrement=false)]

	[ExplicitColumns]
    public partial class SprintRetrospectiveItem : CheetahPocoModelDB.Record<SprintRetrospectiveItem>  
    {



		[Column] public int Id { get; set; }





		[Column] public string Description { get; set; }





		[Column] public int SprintRetrospectiveId { get; set; }





		[Column] public DateTime CreatedAt { get; set; }





		[Column] public Guid CreatedBy { get; set; }





		[Column] public DateTime LastUpdatedAt { get; set; }





		[Column] public Guid LastUpdatedBy { get; set; }



	}

    
	[TableName("Sprints")]


	[PrimaryKey("Id")]



	[ExplicitColumns]
    public partial class Sprint : CheetahPocoModelDB.Record<Sprint>  
    {



		[Column] public int Id { get; set; }





		[Column] public string Name { get; set; }





		[Column] public string Goal { get; set; }





		[Column] public DateTime CreatedAt { get; set; }





		[Column] public Guid CreatedBy { get; set; }





		[Column] public DateTime LastUpdatedAt { get; set; }





		[Column] public Guid LastUpdatedBy { get; set; }



	}

    
	[TableName("AccessTokens")]


	[PrimaryKey("Id")]



	[ExplicitColumns]
    public partial class AccessToken : CheetahPocoModelDB.Record<AccessToken>  
    {



		[Column] public int Id { get; set; }





		[Column] public Guid UserId { get; set; }





		[Column] public string Token { get; set; }





		[Column] public DateTime Expires { get; set; }





		[Column] public DateTime CreatedAt { get; set; }



	}

    
	[TableName("PasswordHashes")]


	[PrimaryKey("Id")]



	[ExplicitColumns]
    public partial class PasswordHash : CheetahPocoModelDB.Record<PasswordHash>  
    {



		[Column] public int Id { get; set; }





		[Column] public Guid UserId { get; set; }





		[Column] public string Hash { get; set; }





		[Column] public DateTime CreatedAt { get; set; }



	}

    
	[TableName("RefreshTokens")]


	[PrimaryKey("Id")]



	[ExplicitColumns]
    public partial class RefreshToken : CheetahPocoModelDB.Record<RefreshToken>  
    {



		[Column] public int Id { get; set; }





		[Column] public Guid UserId { get; set; }





		[Column] public string Token { get; set; }





		[Column] public DateTime CreatedAt { get; set; }



	}

    
	[TableName("Users")]


	[PrimaryKey("Id")]



	[ExplicitColumns]
    public partial class User : CheetahPocoModelDB.Record<User>  
    {



		[Column] public int Id { get; set; }





		[Column] public Guid UserId { get; set; }





		[Column] public string Username { get; set; }





		[Column] public DateTime CreatedAt { get; set; }





		[Column] public Guid ClientId { get; set; }



	}


}



