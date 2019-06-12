using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ClubAdministration.Core.Contracts;
using ClubAdministration.Core.Entities;
using ClubAdministration.Persistence.Validations;
using Microsoft.EntityFrameworkCore;

namespace ClubAdministration.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private bool _disposed;
        private readonly DublicateValidation _duplicateValidation;


        public UnitOfWork()
        {
            _dbContext = new ApplicationDbContext();
            MemberRepository = new MemberRepository(_dbContext);
            SectionRepository = new SectionRepository(_dbContext);
            MemberSectionRepository = new MemberSectionRepository(_dbContext);
            _duplicateValidation = new DublicateValidation(this);
        }

        public IMemberRepository MemberRepository { get; }
        public ISectionRepository SectionRepository { get; }
        public IMemberSectionRepository MemberSectionRepository { get; }



        /// <summary>
        /// Repository-übergreifendes Speichern der Änderungen
        /// </summary>
        public int SaveChanges()
        {
            var entities = _dbContext.ChangeTracker.Entries()
                .Where(entity => entity.State == EntityState.Added
                                 || entity.State == EntityState.Modified)
                .Select(e => e.Entity);
            foreach (var entity in entities)
            {
                ValidateEntity(entity);
            }

            try
            {
                return _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
        public void DeleteDatabase() => _dbContext.Database.EnsureDeleted();
        public void MigrateDatabase() => _dbContext.Database.Migrate();

        private void ValidateEntity(object entity)
        {
            ValidationResult result = null;

            result =_duplicateValidation.GetValidationResult(entity, new ValidationContext(entity));

            if(result != ValidationResult.Success && result != null)
            {
                throw new ValidationException(result, _duplicateValidation, entity);
            }
        }

    }
}
