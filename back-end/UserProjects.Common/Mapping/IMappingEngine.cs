﻿namespace UserProjects.Common.Mapping
{
    public interface IMappingEngine
    {
        TDestiny Map<TSource, TDestiny>(TSource source);

        TSource Update<TSource, TCopyFrom>(TSource source, TCopyFrom copyFrom);
    }
}
