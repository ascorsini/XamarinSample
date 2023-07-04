using BaseProject.Bibliotecas;
using BaseProject.Models;
using BaseProject.Storage.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BaseProject.Storage
{
    public class DatabaseManager
    {
        SQLiteAsyncConnection db;

        public DatabaseManager()
        {
            db = DependencyService.Get<ISQLite>().GetConnection();
        }

        public async Task<int> Save<T>(T value) where T : IKeyObject, new()
        {
            await CreateTable<T>();

            if (await Get<T>(value.Key) == null)
                await db.InsertAsync(value);
            else
                await db.UpdateAsync(value);

            return value.Key.ToInt();
        }

        public async Task<int> InsertAll<T>(IEnumerable<T> value) where T : IKeyObject, new()
        {
            return await db.InsertAllAsync(value);
        }

        public async Task<List<T>> GetAll<T>() where T : IKeyObject, new()
        {
            await CreateTable<T>();

            return await db.Table<T>().ToListAsync();
        }

        public async Task<List<T>> GetWhere<T>(Expression<Func<T, bool>> where) where T : IKeyObject, new()
        {
            await CreateTable<T>();

            return await db.Table<T>().Where(where).ToListAsync();
        }

        public async Task<T> GetFirstWhere<T>(Expression<Func<T, bool>> where) where T : IKeyObject, new()
        {
            await CreateTable<T>();

            return await db.Table<T>().Where(where).FirstOrDefaultAsync();
        }

        public async Task<T> GetFirst<T>() where T : IKeyObject, new()
        {
            await CreateTable<T>();

            return await db.Table<T>().FirstOrDefaultAsync();
        }

        public async Task<T> Get<T>(string id) where T : IKeyObject, new()
        {
            await CreateTable<T>();

            return await db.FindAsync<T>(id);
        }

        public async Task<int> Delete<T>(int id) where T : IKeyObject, new()
        {
            await CreateTable<T>();

            return await db.DeleteAsync<T>(id);
        }

        public async Task<int> DeleteWhere<T>(Expression<Func<T, bool>> where) where T : IKeyObject, new()
        {
            await CreateTable<T>();

            return await db.Table<T>().DeleteAsync(where);
        }

        public async Task<int> DeleteAll<T>() where T : IKeyObject, new()
        {
            await CreateTable<T>();

            return await db.DeleteAllAsync<T>();
        }

        public async Task<bool> DropTable<T>() where T : IKeyObject, new()
        {
            try
            {
                if (await HasTable<T>())
                    await db.DropTableAsync<T>();

                return await Task.FromResult(true);
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine(ex);
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> HasTable<T>()
        {
            string cmdText = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{typeof(T).Name}'";
            var cmd = await db.ExecuteScalarAsync<string>(cmdText);
            return cmd != null;
        }

        private async Task<bool> CreateTable<T>() where T : new()
        {
            try
            {
                if (!await HasTable<T>())
                    await db.CreateTableAsync<T>();

                return await Task.FromResult(true);
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine(ex);
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> HasColumn<T>(string coluna)
        {
            if (await HasTable<T>())
            {
                string cmdText = $"SELECT COUNT(*) FROM pragma_table_info('{typeof(T).Name}') WHERE name='{coluna}'";
                var cmd = await db.ExecuteScalarAsync<int>(cmdText);
                return cmd > 0;
            }
            return true;
        }
    }
}
