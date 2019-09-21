using Unity.Mathematics;

namespace TicTacToe.Models
{
    
    public interface IGameField
    {
    
        int2 Size { get; }

        CellSign this[int2 pos] { get; }
        
    }
    
}