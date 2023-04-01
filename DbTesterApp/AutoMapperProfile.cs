using AutoMapper;
using DbTesterApp.DTO;
using DbTesterApp.Models.NoSql;
using DbTesterApp.Models.Sql;
using System;

namespace DbTesterApp;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Number, NumberNoSql>();
        CreateMap<NumberNoSql, Number>();

        CreateMap<Point, PointNoSql>();
        CreateMap<PointNoSql, Point>();

        CreateMap<Vector, VectorNoSql>();
        CreateMap<VectorNoSql, Vector>();

        CreateMap<Book, BookNoSql>();
        CreateMap<BookNoSql, Book>();

        CreateMap<Worker, WorkerNoSql>();
        CreateMap<WorkerNoSql, Worker>();

        CreateMap<Library, LibraryNoSql>();
        CreateMap<LibraryNoSql, Library>();

        CreateMap<Organization, OrganizationNoSql>();
        CreateMap<OrganizationNoSql, Organization>();

        CreateMap<DataHolderSql, DataHolderNoSql>();
        CreateMap<DataHolderNoSql, DataHolderSql>();
    }  
}

