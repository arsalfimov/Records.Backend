using System;
using Microsoft.EntityFrameworkCore;
using Records.Domain;
using Records.Persistence;

namespace Records.Tests.Common
{
	public class RecordsContextFactory
	{
		public static Guid UserAId = Guid.NewGuid();
		public static Guid UserBId = Guid.NewGuid();

		public static Guid RecordIdForDelete = Guid.NewGuid();
		public static Guid RecordIdForUpdate = Guid.NewGuid();

		public static RecordsDbContext Create()
		{
			var options = new DbContextOptionsBuilder<RecordsDbContext>()
				.UseInMemoryDatabase(Guid.NewGuid().ToString())
				.Options;
			var context = new RecordsDbContext(options);
			context.Database.EnsureCreated();
			context.Records.AddRange(
				new Record
				{
					CreationDate = DateTime.Today,
					Details = "Details1",
					EditDate = null,
					Id = Guid.Parse("{43689AB1-37B5-4F32-815B-17D93C28A6D8}"),
					Title = "Title1",
					UserId = UserAId
				},
				new Record
				{
					CreationDate = DateTime.Today,
					Details = "Details2",
					EditDate = null,
					Id = Guid.Parse("{96339AD8-13B1-421F-AE18-D699A331EFF5}"),
					Title = "Title2",
					UserId = UserBId
				},
				new Record
				{
					CreationDate = DateTime.Today,
					Details = "Details3",
					EditDate = null,
					Id = RecordIdForDelete,
					Title = "Title3",
					UserId = UserAId
				},
				new Record
				{
					CreationDate = DateTime.Today,
					Details = "Details4",
					EditDate = null,
					Id = RecordIdForUpdate,
					Title = "Title4",
					UserId = UserBId
				}
			);
			context.SaveChanges();
			return context;
		}

		public static void Destroy(RecordsDbContext context)
		{
			context.Database.EnsureDeleted();
			context.Dispose();
		}
	}
}
