namespace ChessMaze
{
    public enum Part
    {
        Empty = (int)'_',
        King = (int)'K',
        Queen = (int)'Q', // FEATURE 4: Must Have Movement for Queen
        Rook = (int)'R',
        Bishop = (int)'B',
        Knight = (int)'N',
        PlayerOnEmpty = (int)'e',
        PlayerOnKing = (int)'k',
        PlayerOnQueen = (int)'q',
        PlayerOnRook = (int)'r',
        PlayerOnBishop = (int)'b',
        PlayerOnKnight = (int)'n'
    }
}
