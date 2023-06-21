using Microsoft.EntityFrameworkCore;
using TimedAssignment.Data.TimedAssignmentContext;
using TimedAssignment.Services.CommentServices;
using TimedAssignment.Services.PostServices;
using TimedAssignment.Services.ReplyServices;
using TimedAssignment.Services.HateServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IHateService, HateService>();
builder.Services.AddScoped<IReplyService, ReplyService>();
builder.Services.AddScoped<ICommentService,CommentService>();
builder.Services.AddScoped<IPostService, PostService>();

builder.Services.AddDbContext<TimedAssignmentDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
