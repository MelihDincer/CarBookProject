using CarBookProject.Application.Features.Mediator.Queries.CommentQueries;
using CarBookProject.Application.Features.Mediator.Results.CommentResults;
using CarBookProject.Application.Interfaces.CommentInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class GetCommentCountByBlogIdQueryHandler : IRequestHandler<GetCommentCountByBlogIdQuery, GetCommentCountByBlogIdQueryResult>
    {
        private readonly ICommentRepository _commentRepository;

        public GetCommentCountByBlogIdQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<GetCommentCountByBlogIdQueryResult> Handle(GetCommentCountByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _commentRepository.GetCommentCount(request.BlogId);
            return new GetCommentCountByBlogIdQueryResult
            {
                CommentCount = value
            };
        }
    }
}
