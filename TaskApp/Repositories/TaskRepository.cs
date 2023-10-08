using TaskApp.Data;
using TaskApp.Models;
using TaskApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TaskApp.Repositories;

public class TaskkRepository : ITaskkRepository
{
    private readonly TaskAppDbContext _taskappDbContext;

    public TaskkRepository(TaskAppDbContext taskappDbContext)
    {
        _taskappDbContext = taskappDbContext;
    }
    
    public async Task<List<Taskk>> GetAllTaskks()
    {
        return await _taskappDbContext.Taskks.ToListAsync();
    }

    public async Task<Taskk> GetTaskkById(int id)
    {
        return await _taskappDbContext.Taskks.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Taskk> AddTaskk(Taskk taskk)
    {
        await _taskappDbContext.Taskks.AddAsync(taskk);
        await _taskappDbContext.SaveChangesAsync();

        return taskk;
    }

    public async Task<Taskk> UpdateTaskk(Taskk taskk, int id)
    {
        Taskk findTaskkById = await GetTaskkById(id);

        if (findTaskkById == null)
            throw new Exception("Taskk not found");

        _taskappDbContext.Entry(findTaskkById).CurrentValues.SetValues(taskk);

        _taskappDbContext.Taskks.Update(findTaskkById);
        await _taskappDbContext.SaveChangesAsync();


        return findTaskkById;
    }

    public async Task<bool> DeleteTaskk(int id)
    {
        Taskk findTaskkById = await GetTaskkById(id);

        if (findTaskkById == null)
            throw new Exception("Taskk not found");

        _taskappDbContext.Taskks.Remove(findTaskkById);
        await _taskappDbContext.SaveChangesAsync();
        return true;
    }
}