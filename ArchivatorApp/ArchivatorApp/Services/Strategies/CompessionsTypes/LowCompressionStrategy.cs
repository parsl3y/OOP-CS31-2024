using System.IO.Compression;
using ArchivatorApp.Services.Interfaces;

namespace ArchivatorApp.Services.Strategies;

public class LowCompressionStrategy : BaseCompressionStrategy
{
    protected override CompressionLevel CompressionLevel => CompressionLevel.NoCompression;
}
