using System;
using DIRS21ToExternalMapperSystem.Exceptions;
using DIRS21ToExternalMapperSystem.Factory;

namespace DIRS21ToExternalMapperSystem.Handler
{
    public class MapHandler
    {
        private readonly MapperFactory _mapperFactory;

        //default constructor
        public MapHandler()
        {
        }

        public MapHandler(MapperFactory mapperFactory)
        {
            _mapperFactory = mapperFactory;
        }

        public object Map(object data, string sourceType, string targetType)
        {
            try
            {
                var mapper = _mapperFactory.GetMapper(sourceType, targetType);
                if (mapper == null)
                {
                    throw new InvalidMappingException($"No mapper found for {sourceType} to {targetType}");
                }

                return mapper.Map(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during mapping from {sourceType} to {targetType}: {ex.Message}");
                throw;
            }
        }

        public object MapToExternal(object data, string internalType, string dtoType, string externalType)
        {
            try
            {
                var dtoMapper = _mapperFactory.GetMapper(internalType, dtoType);
                var dto = dtoMapper.Map(data);

                var externalMapper = _mapperFactory.GetMapper(dtoType, externalType);
                var externalModel = externalMapper.Map(dto);

                return externalModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during mapping from {internalType} to {externalType}: {ex.Message}");
                throw;
            }
        }
    }

}

