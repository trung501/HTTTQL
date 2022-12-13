
from rest_framework import viewsets
from ..models import CameraInfo
from django.db import connection
from .serializers import CameraInfoSerializer
from rest_framework.response import Response
from rest_framework.decorators import action
from drf_yasg.utils import swagger_auto_schema
from drf_yasg import openapi
from rest_framework import status
from common import generics_cursor, custom_permission
from rest_framework import permissions
import json

class CameraInfoPermission(custom_permission.CustomPermissions):
    def __init__(self):
        super().__init__()

    # def get_allowed_methods(self, username):
    #     ## query in database here
    #     username = username
    #     return ['GET']

class CameraInfoViewSet(viewsets.ViewSet):
    """
    Interact with CameraInfo
    """
    queryset = CameraInfo.objects.all()
    permission_classes = [CameraInfoPermission]  #Cusstom permission for CameraInfoViewSet

    # all swagger's parameters should be defined here    
    sw_page = openapi.Parameter(
        name='page', type=openapi.TYPE_STRING, description="Page number", in_=openapi.IN_QUERY)
    sw_size = openapi.Parameter(
        name='size', type=openapi.TYPE_STRING, description="Number of results to return per page", in_=openapi.IN_QUERY)
    sw_camera_status = openapi.Parameter(
        name='camera_status', type=openapi.TYPE_STRING,default='On', description="Camera_status", in_=openapi.IN_QUERY)
    sw_camera_groupid = openapi.Parameter(
        name='camera_groupid', type=openapi.TYPE_STRING,default='testGroupCamera', description="Camera_groupid", in_=openapi.IN_QUERY)
    sw_camera_name = openapi.Parameter(
        name='camera_name', type=openapi.TYPE_STRING,default='test Camera', description="Camera_name", in_=openapi.IN_QUERY)
    sw_commune_code = openapi.Parameter(
        name='commune_code', type=openapi.TYPE_STRING, default='145', description="Commune code", in_=openapi.IN_QUERY)
    sw_district_code = openapi.Parameter(
        name='district_code', type=openapi.TYPE_STRING, default='1', description="District code", in_=openapi.IN_QUERY)
    sw_province_code = openapi.Parameter(
        name='province_code', type=openapi.TYPE_STRING, default='10', description="Province code", in_=openapi.IN_QUERY)
    sw_nation_code = openapi.Parameter(
        name='nation_code', type=openapi.TYPE_STRING, default='VNM', description="Nation code", in_=openapi.IN_QUERY)
    sw_number_cam = openapi.Parameter(
        name='number_cam', type=openapi.TYPE_INTEGER, default=4, description="Number camera random", in_=openapi.IN_QUERY)   
    sw_camera_code = openapi.Parameter(
        name='camera_code', type=openapi.TYPE_STRING, default="testCameraInfo", description="Camera code", in_=openapi.IN_QUERY)   
    sw_warehouse_code = openapi.Parameter(
        name='warehouse_code', type=openapi.TYPE_STRING, default='testWarehouse', description="Warehouse code", in_=openapi.IN_QUERY)
    sw_list_camera = openapi.Parameter(
        name='list_camera', type=openapi.TYPE_OBJECT, default={"data":[{"code":"01","camera_name":"cam HCM"},{"code":"02","camera_name":"cam HN"}]}, description="List Camera", in_=openapi.IN_QUERY)

    sw_status_priority = openapi.Parameter(
        name='status_priority', type=openapi.TYPE_INTEGER, default=1, description="Status priority", in_=openapi.IN_QUERY)
  
    get_list_camera_response = {
        status.HTTP_500_INTERNAL_SERVER_ERROR: 'INTERNAL_SERVER_ERROR',
        status.HTTP_204_NO_CONTENT: 'NO_CONTENT',
        status.HTTP_200_OK: 'JSON',
    }
    post_list_camera_response = {
        status.HTTP_500_INTERNAL_SERVER_ERROR: 'INTERNAL_SERVER_ERROR',
        status.HTTP_304_NOT_MODIFIED: 'NOT_MODIFIED',
        status.HTTP_200_OK: 'JSON',
    }

    # Tim kiem Camera theo cac thong tin camera
    @swagger_auto_schema(method='get', manual_parameters=[sw_page,sw_size,sw_camera_groupid,sw_camera_status,sw_camera_name,sw_commune_code,sw_district_code,sw_province_code,sw_nation_code,sw_warehouse_code],
                         responses=get_list_camera_response)
    @action(methods=['GET'], detail=False, url_path='get-list-camera-by-infoCamera')
    def get_list_camera_by_infoCamera(self, request):
        """
        Get Camera info from input. You don't need type full input paramater, it's filter follow input paramater you type
        input: user code, camera_groupid, camera_status, camera_name, commune_code, district_code, province_code, warehouse_code
        output: list Camera belong to user, name camera, location camera
        """
        try: 
            page=request.query_params.get('page')
            size=request.query_params.get('size')
            user_name=request.user
            camera_groupid =  request.query_params.get('camera_groupid')
            camera_status =  request.query_params.get('camera_status')
            camera_name = request.query_params.get('camera_name')
            commune_code = request.query_params.get('commune_code')
            district_code = request.query_params.get('district_code')
            province_code = request.query_params.get('province_code')
            nation_code = request.query_params.get('nation_code')
            warehouse_code = request.query_params.get('warehouse_code')
            param=[str(user_name)]
            select_string= "CAMERA_INFO.CODE,CAMERA_INFO.NAME_CAM,CAMERA_INFO.ID_CAM,CAMERA_STATUS.STATUS "
            join_string = "INNER JOIN USER_CAM ON USER_CAM.CAMERA_CODE = CAMERA_INFO.CODE  " \
                          "INNER JOIN USER_LIST ON USER_CAM.USERNAME = USER_LIST.USERNAME  "\
                          "LEFT JOIN WAREHOUSE_LIST ON CAMERA_INFO.WAREHOUSE_CODE=WAREHOUSE_LIST.CODE " \
                          "LEFT JOIN CAMERA_STATUS ON CAMERA_INFO.LAST_CAMERA_STATUS_CODE = CAMERA_STATUS.CODE "
            condition_string= "USER_LIST.USERNAME = %s AND CAMERA_INFO.STATUS = 1 "
            
            if camera_groupid is not None:
                join_string=join_string + "LEFT JOIN GROUP_CAM ON GROUP_CAM.CAMERA_CODE = CAMERA_INFO.CODE "
                condition_string=condition_string+"AND GROUP_CAM.GROUP_CODE = %s "
                param.append(camera_groupid)
            if camera_status is not None:
                condition_string=condition_string+"AND LOWER(CAMERA_STATUS.STATUS) = LOWER(%s) "
                param.append(camera_status)
            if commune_code is not None:
                condition_string=condition_string+"AND WAREHOUSE_LIST.COMMUNE_CODE =  %s "
                param=param+ [commune_code]
            if district_code is not None:
                condition_string=condition_string+"AND WAREHOUSE_LIST.DISTRICT_CODE = %s "
                param.append(district_code) 
            if province_code is not None:
                condition_string=condition_string+"AND WAREHOUSE_LIST.PROVINCE_CODE = %s "
                param.append(province_code) 
            if nation_code is not None:
                condition_string=condition_string+"AND WAREHOUSE_LIST.NATION_CODE = %s "
                param.append(nation_code) 
            if warehouse_code is not None:
                condition_string=condition_string+"AND CAMERA_INFO.WAREHOUSE_CODE = %s "
                param.append(warehouse_code) 
            if camera_name is not None:
                condition_string=condition_string+"AND LOWER(CAMERA_INFO.NAME_CAM) LIKE LOWER(%s) "
                param.append("%%"+camera_name+"%%") 

            query_string = f"SELECT {select_string} FROM CAMERA_INFO {join_string} WHERE {condition_string} "                      
            obj = generics_cursor.getDictFromQuery(query_string,param,page,size)
            if obj is None:
                return Response(data={}, status=status.HTTP_204_NO_CONTENT)
        except:
            return Response(data={}, status=status.HTTP_500_INTERNAL_SERVER_ERROR)
        return Response(data=obj, status=status.HTTP_200_OK)

    # Lay n camera bat ki thuoc quyen xem cua nguoi dung
    @swagger_auto_schema(method='get', manual_parameters=[sw_page,sw_size,sw_number_cam],
                         responses=get_list_camera_response)
    @action(methods=['GET'], detail=False, url_path='get-random-camera-by-numberCamera')
    def get_random_camera_by_numberCamera(self, request):
        """
        Get Camera info from input
        input: user code, number camera
        output: list Camera belong to user, name camera, location camera
        """
        try:
            username = request.user
            page=request.query_params.get('page')
            size=request.query_params.get('size')
            n_random_camera =  request.query_params.get('number_cam')
            param=[username, int(n_random_camera)]
            query_string =  f"SELECT *"\
                            f"FROM ("\
                                f"SELECT CAMERA_INFO.CODE,CAMERA_INFO.NAME_CAM,CAMERA_INFO.ID_CAM, CAMERA_STATUS.STATUS, CAMERA_INFO.RTSP_PHU FROM CAMERA_INFO "\
                                    f"INNER JOIN CAMERA_STATUS ON CAMERA_INFO.LAST_CAMERA_STATUS_CODE = CAMERA_STATUS.CODE "\
                                    f"INNER JOIN USER_CAM ON USER_CAM.CAMERA_CODE = CAMERA_INFO.CODE "\
                                    f"INNER JOIN WAREHOUSE_LIST ON CAMERA_INFO.WAREHOUSE_CODE=WAREHOUSE_LIST.CODE "\
                                    f"WHERE CAMERA_INFO.STATUS = 1 AND CAMERA_STATUS.STATUS = 'On' AND USER_CAM.USERNAME = %s ORDER BY DBMS_RANDOM.RANDOM) "\
                                f"WHERE  rownum <= %s "
                
            obj = generics_cursor.getDictFromQuery(query_string,param,page,size)
            if obj is None:
                return Response(data={}, status=status.HTTP_204_NO_CONTENT)
        except:
            return Response(data={}, status=status.HTTP_500_INTERNAL_SERVER_ERROR)
        return Response(data=obj, status=status.HTTP_200_OK)

    # Tim kiem Camera theo ma camera
    @swagger_auto_schema(method='get', manual_parameters=[sw_camera_code],
                         responses=get_list_camera_response)
    @action(methods=['GET'], detail=False, url_path='get-list-camera-by-codeCamera')
    def get_list_camera_by_codeCamera(self, request):
        """
        Get Camera info from input
        input: cam_code
        output: list Camera : source, province, commune, location, rtsp
        """
        try:
            username='camera'
            camera_code =  request.query_params.get('camera_code')
            param=[camera_code,username]
            select_string= "CAMERA_INFO.CODE,CAMERA_INFO.NAME_CAM,CAMERA_INFO.ID_CAM,CAMERA_INFO.WAREHOUSE_CODE,WAREHOUSE_LIST.SUJECT_NAME WAREHOUSE_NAME,"\
                           "COMMUNE.COMMUNE_NAME,DISTRICT.DISTRICT_NAME,PROVINCE.SUBJECT_NAME, "\
                           "NATION.NAME_VN NATION_NAME_VN,CAMERA_INFO.RTSP_CHINH,CAMERA_INFO.RTSP_PHU, "\
                           "CAMERA_INFO.CAM_LOCATION,CAMERA_INFO.LAST_CAMERA_STATUS_CODE,CAMERA_STATUS.STATUS,CAMERA_INFO.TYPE_CAMERA, "\
                           "WAREHOUSE_LIST.LONGITUDE,WAREHOUSE_LIST.LATITUDE,COMPANY.NAME COMPANY_NAME  "
            join_string = "LEFT JOIN WAREHOUSE_LIST ON CAMERA_INFO.WAREHOUSE_CODE=WAREHOUSE_LIST.CODE " \
                          "LEFT JOIN COMMUNE ON COMMUNE.CODE = WAREHOUSE_LIST.COMMUNE_CODE "\
                          "LEFT JOIN DISTRICT ON DISTRICT.CODE = WAREHOUSE_LIST.DISTRICT_CODE "\
                          "LEFT JOIN PROVINCE ON PROVINCE.CODE = WAREHOUSE_LIST.PROVINCE_CODE "\
                          "LEFT JOIN NATION ON NATION.CODE = WAREHOUSE_LIST.NATION_CODE "\
                          "LEFT JOIN COMPANY ON COMPANY.CODE = CAMERA_INFO.COMPANY_CODE "\
                          "LEFT JOIN CAMERA_STATUS ON CAMERA_INFO.LAST_CAMERA_STATUS_CODE = CAMERA_STATUS.CODE "\
                          "INNER JOIN USER_CAM ON USER_CAM.CAMERA_CODE = CAMERA_INFO.CODE "
            condition_string= "CAMERA_INFO.CODE = %s  AND USER_CAM.USERNAME = %s AND CAMERA_INFO.STATUS = 1"            

            query_string = f"SELECT {select_string} FROM CAMERA_INFO {join_string} WHERE {condition_string} "  
                
            obj = generics_cursor.getDictFromQuery(query_string,param)
            if obj is None:
                return Response(data={}, status=status.HTTP_204_NO_CONTENT)
        except:
            return Response(data={}, status=status.HTTP_500_INTERNAL_SERVER_ERROR)
        return Response(data=obj, status=status.HTTP_200_OK)
    
     # Hiển thị thông tin camera khi hover vào map
    @swagger_auto_schema(method='get', manual_parameters=[sw_warehouse_code],
                         responses=get_list_camera_response)
    @action(methods=['GET'], detail=False, url_path='get-info-camera-when-hoverCamera')
    def get_info_camera_when_hoverCamera(self, request):
        """
        Get Camera info from input. You don't need type full input paramater, it's filter follow input paramater you type
        input: warehouse_code
        output: list Camera belong to user, name camera, location camera
        """
        try: 
            user_name=request.user
            warehouse_code =  request.query_params.get('warehouse_code')
            param=[str(user_name), str(warehouse_code)]

            query_string =  f"SELECT COMMUNE.COMMUNE_NAME , DISTRICT.DISTRICT_NAME, PROVINCE.SUBJECT_NAME, NATION.NAME_VN, WAREHOUSE_LIST.ADDRESS_DETAIL, " \
                                    f"SUM(case when LOWER(CAMERA_STATUS.STATUS) = LOWER('On') then 1 else 0 end )AS NUMBER_CAM_ON, " \
                                    f"SUM(case when LOWER(CAMERA_STATUS.STATUS) = LOWER('Off') then 1 else 0 end )AS NUMBER_CAM_OFF " \
                                    f"FROM CAMERA_INFO "\
                                    f"INNER JOIN CAMERA_STATUS ON CAMERA_INFO.LAST_CAMERA_STATUS_CODE = CAMERA_STATUS.CODE "\
                                    f"INNER JOIN USER_CAM ON USER_CAM.CAMERA_CODE = CAMERA_INFO.CODE "\
                                    f"INNER JOIN WAREHOUSE_LIST ON CAMERA_INFO.WAREHOUSE_CODE=WAREHOUSE_LIST.CODE "\
                                    f"INNER JOIN COMMUNE on WAREHOUSE_LIST.COMMUNE_CODE = COMMUNE.CODE "\
                                    f"INNER JOIN PROVINCE on WAREHOUSE_LIST.PROVINCE_CODE = PROVINCE.CODE "\
                                    f"INNER JOIN NATION on WAREHOUSE_LIST.NATION_CODE = NATION.CODE "\
                                    f"INNER JOIN DISTRICT ON WAREHOUSE_LIST.DISTRICT_CODE = DISTRICT.CODE "\
                                    f"WHERE USER_CAM.USERNAME = %s AND CAMERA_INFO.STATUS = 1 AND WAREHOUSE_LIST.CODE = %s "\
                                    f"group by COMMUNE.COMMUNE_NAME, DISTRICT.DISTRICT_NAME, PROVINCE.SUBJECT_NAME, NATION.NAME_VN,WAREHOUSE_LIST.ADDRESS_DETAIL "
                
            obj = generics_cursor.getDictFromQuery(query_string,param)
            if obj is None:
                return Response(data={}, status=status.HTTP_204_NO_CONTENT)
        except:
            return Response(data={}, status=status.HTTP_500_INTERNAL_SERVER_ERROR)
        return Response(data=obj, status=status.HTTP_200_OK)
    
    # Hiển thị thông tin tọa độ, danh sách camera khi hover vào map
    @swagger_auto_schema(method='get', manual_parameters=[sw_page,sw_size,sw_warehouse_code],
                         responses=get_list_camera_response)
    @action(methods=['GET'], detail=False, url_path='get-list-camera-when-hoverCamera')
    def get_list_camera_when_hoverCamera(self, request):
        """
        Get Camera info from input. You don't need type full input paramater, it's filter follow input paramater you type
        input: warehouse_code
        output: list Camera belong to user, name camera, location camera
        """
        try: 
            page=request.query_params.get('page')
            size=request.query_params.get('size')
            user_name=request.user
            warehouse_code =  request.query_params.get('warehouse_code')
            param=[str(user_name), str(warehouse_code)]

            query_string =  f"SELECT CAMERA_INFO.STATUS, CAMERA_INFO.NAME_CAM, CAMERA_INFO.RTSP_PHU, WAREHOUSE_LIST.LONGITUDE, WAREHOUSE_LIST.LATITUDE " \
                                    f"FROM CAMERA_INFO "\
                                    f"INNER JOIN CAMERA_STATUS ON CAMERA_INFO.LAST_CAMERA_STATUS_CODE = CAMERA_STATUS.CODE "\
                                    f"INNER JOIN USER_CAM ON USER_CAM.CAMERA_CODE = CAMERA_INFO.CODE "\
                                    f"INNER JOIN WAREHOUSE_LIST ON CAMERA_INFO.WAREHOUSE_CODE=WAREHOUSE_LIST.CODE "\
                                    f"INNER JOIN COMMUNE on WAREHOUSE_LIST.COMMUNE_CODE = COMMUNE.CODE "\
                                    f"INNER JOIN PROVINCE on WAREHOUSE_LIST.PROVINCE_CODE = PROVINCE.CODE "\
                                    f"INNER JOIN NATION on WAREHOUSE_LIST.NATION_CODE = NATION.CODE "\
                                    f"INNER JOIN DISTRICT ON WAREHOUSE_LIST.DISTRICT_CODE = DISTRICT.CODE "\
                                    f"WHERE USER_CAM.USERNAME = %s AND CAMERA_INFO.STATUS = 1 AND WAREHOUSE_LIST.CODE = %s AND LOWER(CAMERA_STATUS.STATUS) = LOWER('On')"\
                
            obj = generics_cursor.getDictFromQuery(query_string,param,page,size)
            if obj is None:
                return Response(data={}, status=status.HTTP_204_NO_CONTENT)
        except:
            return Response(data={}, status=status.HTTP_500_INTERNAL_SERVER_ERROR)
        return Response(data=obj, status=status.HTTP_200_OK)

    # Lấy ra danh sách kho thuộc quản lý người dùng
    @swagger_auto_schema(method='get', manual_parameters=[sw_page, sw_size],
                         responses=get_list_camera_response)
    @action(methods=['GET'], detail=False, url_path='get-list-warehouse-by-username')
    def get_list_warehouse_by_username(self, request):
        """
        Get Warehouse info by username
        input: None
        output: list Warehouse belong to user
        """
        try: 
            page=request.query_params.get('page')
            size=request.query_params.get('size')
            user_name=request.user
            param=[str(user_name)]

            query_string =  f"SELECT DISTINCT WAREHOUSE_LIST.CODE, WAREHOUSE_LIST.SUJECT_NAME, WAREHOUSE_LIST.LONGITUDE, WAREHOUSE_LIST.LATITUDE, " \
                            f"WAREHOUSE_LIST.ADDRESS_DETAIL, WAREHOUSE_LIST.COMMUNE_CODE, WAREHOUSE_LIST.DISTRICT_CODE, WAREHOUSE_LIST.PROVINCE_CODE, WAREHOUSE_LIST.NATION_CODE "\
                                    f"FROM CAMERA_INFO "\
                                    f"INNER JOIN CAMERA_STATUS ON CAMERA_INFO.ID_CAM = CAMERA_STATUS.ID_CAM "\
                                    f"INNER JOIN USER_CAM ON USER_CAM.CAMERA_CODE = CAMERA_INFO.CODE "\
                                    f"INNER JOIN WAREHOUSE_LIST ON CAMERA_INFO.WAREHOUSE_CODE=WAREHOUSE_LIST.CODE "\
                                    f"INNER JOIN COMMUNE on WAREHOUSE_LIST.COMMUNE_CODE = COMMUNE.CODE "\
                                    f"INNER JOIN PROVINCE on WAREHOUSE_LIST.PROVINCE_CODE = PROVINCE.CODE "\
                                    f"INNER JOIN NATION on WAREHOUSE_LIST.NATION_CODE = NATION.CODE "\
                                    f"INNER JOIN DISTRICT ON WAREHOUSE_LIST.DISTRICT_CODE = DISTRICT.CODE "\
                                    f"WHERE USER_CAM.USERNAME = %s AND CAMERA_INFO.STATUS = 1 "\
                
            obj = generics_cursor.getDictFromQuery(query_string,param,page,size)
            if obj is None:
                return Response(data={}, status=status.HTTP_204_NO_CONTENT)
        except:
            return Response(data={}, status=status.HTTP_500_INTERNAL_SERVER_ERROR)
        return Response(data=obj, status=status.HTTP_200_OK)

    # Lay danh sach camera uu tien
    @swagger_auto_schema(method='get', manual_parameters=[sw_page,sw_size],
                         responses=get_list_camera_response)
    @action(methods=['GET'], detail=False, url_path='get-list-camera-priority')
    def get_list_camera_priority(self, request):
        """
        Get Camera prority of current user
        input: user code,
        output: list Camera prority code 
        """
        try:
            page=request.query_params.get('page')  
            size=request.query_params.get('size')
            self.username=str(request.user)
            param=[self.username]
            query_string = f"SELECT USER_LIST.CODE,USER_CAM.CAMERA_CODE " \
                           f"FROM USER_LIST " \
                           f"INNER JOIN USER_CAM ON USER_CAM.USERNAME = USER_LIST.USERNAME " \
                           f"INNER JOIN CAMERA_INFO ON CAMERA_INFO.CODE = USER_CAM.CAMERA_CODE " \
                           f"WHERE USER_LIST.USERNAME = %s " \
                           f"AND USER_CAM.PRIORITIZED= 1 AND CAMERA_INFO.STATUS=1 " 
                 
            obj = generics_cursor.getDictFromQuery(query_string,param,page,size)
            if obj is None:
                return Response(data={}, status=status.HTTP_204_NO_CONTENT)
        except:
            return Response(data={}, status=status.HTTP_500_INTERNAL_SERVER_ERROR)
        return Response(data=obj, status=status.HTTP_200_OK)


    # Set trang thai camera uu tien
    @swagger_auto_schema(method='put', manual_parameters=[sw_camera_code,sw_status_priority],
                         responses=post_list_camera_response)
    @action(methods=['PUT'], detail=False, url_path='put-set-status-camera-priority')
    def put_set_status_camera_priority(self, request):
        """
        Set status prority for camera
        input: user code, camera code, startus prority
        output: list Camera prority code 
        """       
        try:
            self.username=str(request.user)
            with connection.cursor() as cursor:
                camera_code=request.query_params.get('camera_code')  
                status_priority=request.query_params.get('status_priority')  
                query_string = f"UPDATE USER_CAM " \
                            f"SET USER_CAM.PRIORITIZED= %s " \
                            f"WHERE USER_CAM.USERNAME = ( SELECT USER_LIST.USERNAME " \
                                                        f" FROM USER_LIST " \
                                                        f" WHERE USER_LIST.USERNAME = %s )" \
                            f"AND USER_CAM.CAMERA_CODE= %s "       
                print(query_string)                      
                param=[0 if int(status_priority)== 0 else 1 ,self.username,camera_code]  
                cursor.execute(query_string,param)
                checkQuerry= cursor.rowcount
            if checkQuerry== 0 :
                return Response(data={"result":False}, status=status.HTTP_304_NOT_MODIFIED)
        except:
            return Response(data={}, status=status.HTTP_500_INTERNAL_SERVER_ERROR)
        return Response(data={"result":True}, status=status.HTTP_200_OK)
    
    # Tim kiem Camera theo ten camera
    @swagger_auto_schema(method='get', manual_parameters=[sw_list_camera,sw_camera_name],
                         responses=get_list_camera_response)
    @action(methods=['GET'], detail=False, url_path='get-list-camera-by-list')
    def get_list_camera_from_list(self, request):
        """
        Get Camera info by list_camera, camera_name from input
        input: list_camera
        output: sub_list_camera
        """
        try:
            camera_name = request.query_params.get('camera_name')
            list_camera=request.query_params.get('list_camera')
            list_camera=json.loads(list_camera)["data"]
            sub_list_camera=[camera for camera in list_camera if camera_name.lower() in camera['camera_name'].lower()]
        except:
            return Response(data={}, status=status.HTTP_500_INTERNAL_SERVER_ERROR)
        return Response(data={"data":sub_list_camera}, status=status.HTTP_200_OK)


    # Lấy ra mã kho, tên kho, vị trí, tọa độ
    @swagger_auto_schema(method='get', manual_parameters=[],
                         responses=get_list_camera_response)
    @action(methods=['GET'], detail=False, url_path='get-list-camera-level-by-username')
    def get_list_camera_level_by_username(self, request):
        """
        Get Warehouse info belong to user
        input: None
        output: list Warehouse belong to user, name camera, location camera
        """
        try: 
            page=request.query_params.get('page')
            user_name=request.user
            param=[str(user_name)]
            all_list_cam_level= []
            query_string =  f"SELECT DISTINCT WAREHOUSE_LIST.CODE, WAREHOUSE_LIST.SUJECT_NAME, WAREHOUSE_LIST.LONGITUDE, WAREHOUSE_LIST.LATITUDE " \
                                    f"FROM CAMERA_INFO "\
                                    f"INNER JOIN USER_CAM ON USER_CAM.CAMERA_CODE = CAMERA_INFO.CODE "\
                                    f"INNER JOIN WAREHOUSE_LIST ON CAMERA_INFO.WAREHOUSE_CODE=WAREHOUSE_LIST.CODE "\
                                    f"INNER JOIN COMMUNE on WAREHOUSE_LIST.COMMUNE_CODE = COMMUNE.CODE "\
                                    f"INNER JOIN PROVINCE on WAREHOUSE_LIST.PROVINCE_CODE = PROVINCE.CODE "\
                                    f"INNER JOIN NATION on WAREHOUSE_LIST.NATION_CODE = NATION.CODE "\
                                    f"INNER JOIN DISTRICT ON WAREHOUSE_LIST.DISTRICT_CODE = DISTRICT.CODE "\
                                    f"WHERE USER_CAM.USERNAME = %s AND CAMERA_INFO.STATUS = 1 "\
                
            obj = generics_cursor.getDictFromQuery(query_string,param,page)
            if obj is None:
                return Response(data={}, status=status.HTTP_204_NO_CONTENT)
            
            for item in obj:
                param_get_list_cam_from_warehouse=[str(user_name), str(item["CODE"])]
                print("param: ",param_get_list_cam_from_warehouse)
                query_string_get_list_cam_from_warehouse =  f"SELECT CAMERA_INFO.CODE,CAMERA_INFO.NAME_CAM,CAMERA_INFO.ID_CAM, CAMERA_STATUS.STATUS " \
                                        f"FROM CAMERA_INFO "\
                                        f"INNER JOIN CAMERA_STATUS ON CAMERA_INFO.LAST_CAMERA_STATUS_CODE = CAMERA_STATUS.CODE "\
                                        f"INNER JOIN USER_CAM ON USER_CAM.CAMERA_CODE = CAMERA_INFO.CODE "\
                                        f"INNER JOIN WAREHOUSE_LIST ON CAMERA_INFO.WAREHOUSE_CODE=WAREHOUSE_LIST.CODE "\
                                        f"WHERE USER_CAM.USERNAME = %s AND CAMERA_INFO.STATUS = 1 AND WAREHOUSE_LIST.CODE = %s "\
                    
                obj_list_cam = generics_cursor.getDictFromQuery(query_string_get_list_cam_from_warehouse,param_get_list_cam_from_warehouse,page)
                all_list_cam_level.append({"WAREHOUSE_CODE":item["CODE"], "WAREHOUSE_NAME":item["SUJECT_NAME"], "LIST_CAMERA":obj_list_cam})
                print(obj_list_cam)
        except:
            return Response(data={}, status=status.HTTP_500_INTERNAL_SERVER_ERROR)
        return Response(data=all_list_cam_level, status=status.HTTP_200_OK)

    # Lấy danh sách camera ưu tiên thuộc quản lý người dùng
    @swagger_auto_schema(method='get', manual_parameters=[sw_page, sw_size],
                         responses=get_list_camera_response)
    @action(methods=['GET'], detail=False, url_path='get-list-priority-camera-level-by-username')
    def get_list_priority_camera_level_by_username(self, request):
        """
        Get list priority Camera info belong to user
        input: None
        output: list Camera belong to user, name camera, location camera
        """
        try: 
            page=request.query_params.get('page')
            size = request.query_params.get('size')
            user_name=request.user
            param=[str(user_name)]
            all_list_cam_level= []
            query_string =  f"SELECT DISTINCT WAREHOUSE_LIST.CODE, WAREHOUSE_LIST.SUJECT_NAME, WAREHOUSE_LIST.LONGITUDE, WAREHOUSE_LIST.LATITUDE " \
                                    f"FROM CAMERA_INFO "\
                                    f"INNER JOIN USER_CAM ON USER_CAM.CAMERA_CODE = CAMERA_INFO.CODE "\
                                    f"INNER JOIN WAREHOUSE_LIST ON CAMERA_INFO.WAREHOUSE_CODE=WAREHOUSE_LIST.CODE "\
                                    f"INNER JOIN COMMUNE on WAREHOUSE_LIST.COMMUNE_CODE = COMMUNE.CODE "\
                                    f"INNER JOIN PROVINCE on WAREHOUSE_LIST.PROVINCE_CODE = PROVINCE.CODE "\
                                    f"INNER JOIN NATION on WAREHOUSE_LIST.NATION_CODE = NATION.CODE "\
                                    f"INNER JOIN DISTRICT ON WAREHOUSE_LIST.DISTRICT_CODE = DISTRICT.CODE "\
                                    f"WHERE USER_CAM.USERNAME = %s AND CAMERA_INFO.STATUS = 1 "\
                
            obj = generics_cursor.getDictFromQuery(query_string,param,page,size)
            if obj is None:
                return Response(data={}, status=status.HTTP_204_NO_CONTENT)
            
            for item in obj:
                param_get_list_cam_from_warehouse=[str(user_name), str(item["CODE"])]
                print("param: ",param_get_list_cam_from_warehouse)
                query_string_get_list_cam_from_warehouse =  f"SELECT CAMERA_INFO.CODE,CAMERA_INFO.NAME_CAM,CAMERA_INFO.ID_CAM, CAMERA_STATUS.STATUS " \
                                        f"FROM CAMERA_INFO "\
                                        f"INNER JOIN CAMERA_STATUS ON CAMERA_INFO.LAST_CAMERA_STATUS_CODE = CAMERA_STATUS.CODE "\
                                        f"INNER JOIN USER_CAM ON USER_CAM.CAMERA_CODE = CAMERA_INFO.CODE "\
                                        f"INNER JOIN WAREHOUSE_LIST ON CAMERA_INFO.WAREHOUSE_CODE=WAREHOUSE_LIST.CODE "\
                                        f"WHERE USER_CAM.USERNAME = %s AND CAMERA_INFO.STATUS = 1 AND WAREHOUSE_LIST.CODE = %s AND USER_CAM.PRIORITIZED = 1 "\
                    
                obj_list_cam = generics_cursor.getDictFromQuery(query_string_get_list_cam_from_warehouse,param_get_list_cam_from_warehouse,page)
                all_list_cam_level.append({"WAREHOUSE_CODE":item["CODE"], "WAREHOUSE_NAME":item["SUJECT_NAME"], "LIST_CAMERA":obj_list_cam})
                print(obj_list_cam)
        except:
            return Response(data={}, status=status.HTTP_500_INTERNAL_SERVER_ERROR)
        return Response(data=all_list_cam_level, status=status.HTTP_200_OK)