

public class Common
{

    public const int MAX_PACKET_SIZE = 1024;
    public const int MAX_NICKNAME_LENGTH = 8;//닉네임 최대 글자수
    public const int TOKEN_SIZE = 20;



    public static readonly int screenWide = 360;
    public static readonly int screenHeight = 640;
  
    public enum ePacketIndex
    {
        eCM_Test,
        eSM_Test,
        eCM_Enter,
        eSM_Enter,
        eCM_Join,
        eSM_Join,
        MAX_FUNC_SIZE
    };


}
