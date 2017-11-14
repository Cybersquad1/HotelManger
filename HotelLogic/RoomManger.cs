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

        public static List<string> GetRoomStatusList()
        {
            List<string> list = new List<string>();
            List<RoomStatus> statuslist = RoomStatusService.GetAllStatus();

            foreach(RoomStatus i in statuslist)
            {
                list.Add(i.RoomStatusName);
            }

            return list;
        }

        public static List<Room> GetRoomList(string TypeName)
        {
            RoomType typenode = RoomTypeService.GetRoomTypeList(TypeName, false)[0];//获取类型节点

            List<Room> list = RoomService.GetRoomListByType(typenode.TypeID);

            return list;
        }

        public static List<RoomManageModel> GetAllModelList()
        {
            List<Room> roomlist = null;
            List<RoomManageModel> modellist = new List<RoomManageModel>();

            roomlist = RoomService.GetRoomList();

            foreach(Room i in roomlist)
            {
                RoomManageModel node = new RoomManageModel();
                node.RoomID = i.RoomID;
                node.Description = i.Description;
                node.RoomName = i.RoomNumber.Trim();
                node.RoomType = RoomTypeService.GetRoomType(i.RoomTypeID).TypeName;
                node.BedNum = i.NumOfBeds;
                node.MaxCustNum = i.NumOfCust;
                node.RoomStatus = RoomStatusService.FindStatusByID(i.RoomStatus).RoomStatusName;
                modellist.Add(node);
            }

            return modellist;

        }

        public static int FindRoomIDByName(string RoomName)
        {
            return RoomService.FindRoomByIDorName(-1, RoomName, 2).RoomID;
        }

        /// <summary>
        /// 修改房间信息
        /// </summary>
        /// <param name="RoomID">修改的房间ID</param>
        /// <param name="RoomName">房间名</param>
        /// <param name="RoomType">房间类型</param>
        /// <param name="NumBed">床数</param>
        /// <param name="NumCust">最大人数</param>
        /// <param name="Status">状态</param>
        /// <param name="type">类型，从0-5</param>
        /// <returns></returns>
        public static int ChangeRoomValue(int RoomID,string RoomName,string RoomType,int NumBed,int NumCust,string Status,string desc,int type)
        {
            switch (type)
            {
                case 0:
                    return RoomService.ChangeRoom(RoomID, RoomName, -1, -1, "", -1, -1, 1);
                case 1:
                    int TypeID = RoomTypeService.GetRoomTypeList(RoomType, false)[0].TypeID;
                    return RoomService.ChangeRoom(RoomID, "", TypeID, -1, "", -1, -1, 2);
                case 2:
                    return RoomService.ChangeRoom(RoomID, "", -1, -1, "", NumBed, -1, 5);
                case 3:
                    return RoomService.ChangeRoom(RoomID, "", -1, -1, "", -1, NumCust, 6);
                case 4:
                    int StatusID = RoomStatusService.FindStatusByKeyword(Status, false)[0].RoomStatusID;
                    return RoomService.ChangeRoom(RoomID, "", -1, StatusID, "", -1, NumCust, 3);
                case 5:
                    return RoomService.ChangeRoom(RoomID, "", -1, -1, desc, -1, -1, 4);
                default:
                    return -1;
            }
        }

        /// <summary>
        /// 添加新房间
        /// </summary>
        /// <param name="RoomName"></param>
        /// <param name="RoomType"></param>
        /// <param name="NumBed"></param>
        /// <param name="NumCust"></param>
        /// <param name="Status"></param>
        /// <param name="desc"></param>
        /// <returns>返回1为插入成功，-1为拒绝插入</returns>
        public static int AddNewRoom(string RoomName,string RoomType,int NumBed,int NumCust,string Status,string desc)
        {
            int typeid=RoomTypeService.GetRoomTypeList(RoomType,false)[0].TypeID;
            int statusid=RoomStatusService.FindStatusByKeyword(Status,false)[0].RoomStatusID;

            return RoomService.AddNewRoom(RoomName, typeid, statusid, desc, NumBed, NumCust);
        }

        /// <summary>
        /// 确认对应状态是否可被删除
        /// </summary>
        /// <param name="statusname"></param>
        /// <returns></returns>
        public static bool IsRemoveable(string statusname)
        {
            return RoomStatusService.FindStatusByKeyword(statusname, false)[0].RoomDeleteAble;
        }

        /// <summary>
        /// 删除房间
        /// </summary>
        /// <param name="roomname"></param>
        /// <returns></returns>
        public static int DeleteRoom(string roomname)
        {
            int roomid = FindRoomIDByName(roomname);

            return RoomService.DeleteRoom(roomid);
        }
    }
}
