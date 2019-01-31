﻿using System.Collections.Generic;

namespace Optivem.Platform.Core.Common.Serialization
{
    public interface ISerializationService
    {
        string Serialize<T>(T record);
        
        T Deserialize<T>(string record);
    }
}