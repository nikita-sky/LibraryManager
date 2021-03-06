﻿using System;
using System.Linq;
using AutoMapper;
using LibraryManager.ActionHandlers.Common;
using LibraryManager.ActionHandlers.Forms;
using LibraryManager.ActionHandlers.ViewModels;
using LibraryManager.Data.Model;
using LibraryManager.Data.Model.Entity;

namespace LibraryManager.ActionHandlers
{
    public class ClientEntryActionHandler : ActionHandler<ClientEntry>
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<LibraryCard> _librarCardRepository;

        public ClientEntryActionHandler(IRepository<ClientEntry> repository, IMapper mapper,
            IRepository<LibraryCard> librarCardRepository, IRepository<Book> bookRepository)
            : base(repository, mapper)
        {
            _librarCardRepository = librarCardRepository;
            _bookRepository = bookRepository;
        }

        public QueryResult<ClientEntryViewModel> Find(FindClientEntryForm form)
        {
            form.Page = Math.Max(1, form.Page);

            var query = Repository.Query();

            if (!string.IsNullOrWhiteSpace(form.BookTitle))
                query = query.Where(x => x.Book.Title.Contains(form.BookTitle));

            if (!string.IsNullOrWhiteSpace(form.ClientFullName))
                query = query.Where(x => x.LibraryCard.FullName.StartsWith(form.ClientFullName));

            if (form.TakedAt != null && form.ReturnAt != null)
                query = query.Where(x => x.TakedAt >= form.TakedAt.Value && x.ReturnAt <= form.ReturnAt.Value);
            else
            {
                if (form.TakedAt != null)
                    query =
                        query.Where(x => x.TakedAt >= form.TakedAt.Value && x.TakedAt <= form.TakedAt.Value.AddDays(1));

                if (form.ReturnAt != null)
                    query =
                        query.Where(
                            x => x.ReturnAt <= form.ReturnAt.Value && x.ReturnAt >= form.ReturnAt.Value.AddDays(-1));
            }

            query = query.OrderBy(x => x.TakedAt);

            var total = query.LongCount();
            var result = query
                .Skip((form.Page - 1)*PageSize)
                .Select(Map<ClientEntryViewModel>)
                .Take(PageSize).ToArray();

            return QueryResult<ClientEntryViewModel>.Success(result, total);
        }

        public new QueryResult<ClientEntryViewModel> Get(int page)
        {
            page = Math.Max(1, page);

            var total = Repository.Total();
            var result = Repository.Query()
                .OrderBy(x => x.TakedAt)
                .Skip((page - 1)*PageSize)
                .Take(PageSize)
                .Select(Map<ClientEntryViewModel>)
                .ToArray();

            return QueryResult<ClientEntryViewModel>.Success(result, total);
        }

        public QueryResult<ClientEntry> Create(CreateClientEntryForm form)
        {
            if (form == null)
                throw new ArgumentNullException(nameof(form));

            if (IsFormInvalid(form))
                return QueryResult<ClientEntry>.BadRequest();

            return Add(Map<ClientEntry>(form));
        }

        public HandledActionResult Update(UpdateClientEntryForm form)
        {
            if (form == null)
                throw new ArgumentNullException(nameof(form));

            if (IsFormInvalid(form))
                return HandledActionResult.BadRequest;

            return Update(Map<ClientEntry>(form));
        }

        private bool IsFormValid(CreateClientEntryForm form)
            => form.IsValid &&
                _bookRepository.Query().Any(x => x.Id == form.BookId) &&
                _librarCardRepository.Query().Any(x => x.Id == form.LibraryCardId);

        private bool IsFormInvalid(CreateClientEntryForm form)
            => !IsFormValid(form);
    }
}