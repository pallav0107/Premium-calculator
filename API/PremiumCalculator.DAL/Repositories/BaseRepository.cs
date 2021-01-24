using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PremiumCalculator.DAL.Databases;
using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculator.DAL.Repositories
{
	public abstract class BaseRepository
	{
		protected readonly TALContext m_context;
		protected IMapper m_mapper;
		public BaseRepository(TALContext context, IMapper mapper)
		{
			m_context = context;
			m_mapper = mapper;
		}

		protected void DBAccess(Action<TALContext> action, bool saveChanges = false)
		{
			if (m_context.Database.CurrentTransaction != null)
			{
				action(m_context);

				if (saveChanges)
				{
					m_context.SaveChanges();
				}
			}
			else
			{
				using (var transaction = m_context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
				{
					action(m_context);

					if (saveChanges)
					{
						m_context.SaveChanges();
					}

					transaction.Commit();
				}
			}
		}


	}
}
