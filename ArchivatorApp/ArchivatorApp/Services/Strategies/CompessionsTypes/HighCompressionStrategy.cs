using System.IO.Compression;
using ArchivatorApp.Services.Interfaces;

namespace ArchivatorApp.Services.Strategies;

public class HighCompressionStrategy : BaseCompressionStrategy
{
    protected override CompressionLevel CompressionLevel => CompressionLevel.Optimal;
}
