using Microsoft.Extensions.Options;
using System;

namespace Algebra.Core
{
    public class Upload: IDisposable
    {
        private readonly AppSettings _variables;
        public Upload(IOptions<AppSettings> options)
        {
            _variables = options.Value;
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
