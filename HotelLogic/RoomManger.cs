using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelDBA;
using HotelModels;

namespace HotelLogic
{
    public class RoomManger
    {
        public static List<string> GetRoomTypeList()
        {
            List<string> list = new List<string>();
            List<RoomType> roomtype = RoomTypeService.GetAllRoomType();

            foreach(RoomType i in roomtype)
            {
                list.Add(i.TypeName);
            }

            return list;
        }

        public static List<Room> GetRoomList(string TypeName)
        {
            RoomType typenode = RoomTypeService.GetRoomTypeList(TypeName, false)[0];//获取类型节点

            List<Room> list = RoomService.GetRoomListByType(typenode.TypeID);

            return list;
        }
    }
}
