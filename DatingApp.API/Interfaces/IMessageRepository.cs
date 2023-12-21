using System;
using DatingApp.API.DTOs;
using DatingApp.API.Entities;
using DatingApp.API.Helpers;

namespace DatingApp.API.Interfaces
{
	public interface IMessageRepository
	{
		void AddMessage(Message message);
		void DeleteMessage(Message message);
		Task<Message> GetMessage(int id);
		Task<PagedList<MessageDto>> GetMessageForUser(MessageParams messageParams);
        Task<IEnumerable<MessageDto>> GetMessageThread(string currentUsername, string recipientUsername);
		Task<bool> SaveAllAsync();

		void AddGroup(Group group);
		void RemoveConnection(Connection connection);
		Task<Connection> GetConnection(string connectionId);
		Task<Group> GetMessageGroup(string groupName);
		Task<Group> GetGroupForConnection(string connectionId);
    }
}

