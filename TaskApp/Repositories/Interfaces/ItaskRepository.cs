using TaskApp.Models;

namespace TaskApp.Repositories.Interfaces;

public interface ITaskkRepository
{
    Task<List<Taskk>> GetAllTaskks();
    Task<Taskk> GetTaskkById(int id);
    Task<Taskk> AddTaskk(Taskk taskk);
    Task<Taskk> UpdateTaskk(Taskk taskk, int id);
    Task<bool> DeleteTaskk(int id);
}