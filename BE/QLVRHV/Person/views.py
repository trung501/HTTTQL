
from rest_framework import viewsets
from django.db import connection
from rest_framework.response import Response
from rest_framework.decorators import action
from drf_yasg.utils import swagger_auto_schema
from drf_yasg import openapi
from rest_framework import status
from rest_framework import pagination
from Common import generics_cursor, custom_permission
from Common.generics import *
from datetime import datetime
class PersonPermission(custom_permission.CustomPermissions):
    def __init__(self):
        super().__init__()

    # def get_allowed_methods(self, username):
    #     ## query in database here
    #     username = username
    #     return ['GET']


# Create your views here.
class PersonViewSet(viewsets.ViewSet):
    """
    Interact with UserCam
    """
    
    permission_classes = [PersonPermission]

    # all swagger's parameters should be defined here 
    sw_page = openapi.Parameter(
        name='page', type=openapi.TYPE_STRING, description="Page number", in_=openapi.IN_QUERY)
    sw_size = openapi.Parameter(
        name='size', type=openapi.TYPE_STRING, description="Number of results to return per page", in_=openapi.IN_QUERY)
    sw_DonViID = openapi.Parameter(
        name='donViID', type=openapi.TYPE_STRING, description="DonViID", in_=openapi.IN_QUERY)
    sw_MaHV = openapi.Parameter(
        name='maHV', type=openapi.TYPE_STRING, description="MaHV",default="201901058", in_=openapi.IN_QUERY)
    sw_TimeStart = openapi.Parameter(
        name='timeStart', type=openapi.TYPE_STRING, description="TimeStart",default="12-08-2022", in_=openapi.IN_QUERY)

    get_list_person_response = {
        status.HTTP_500_INTERNAL_SERVER_ERROR: 'INTERNAL_SERVER_ERROR',
        status.HTTP_204_NO_CONTENT: 'NO_CONTENT',
        status.HTTP_200_OK: 'JSON',
    }

    def CheckQuyetDinhCamTrai(self,maHV,time_go:"12-08-2022"):
        try:
            time_go = datetime.strptime(time_go, '%d-%m-%Y').date()
            query_string=f'SELECT * FROM QUYETDINHCAMTRAI \
                            WHERE MAHV = %s \
                            AND TG_BatDau <= %s\
                            AND TG_BatDau <= %s  '            
            obj=generics_cursor.getDictFromQuery(query_string,[maHV,time_go,time_go])
            if len(obj) > 0 :
                return True,obj
        except:
            return True,[]
        return False,[]
        


    @swagger_auto_schema(method='get', manual_parameters=[sw_page,sw_size,sw_DonViID], responses=get_list_person_response)
    @action(methods=['GET'], detail=False, url_path='get-list-hoc-vien')
    def get_list_hoc_vien(self, request):
        page =request.query_params.get('page')
        size =request.query_params.get('size')
        donViID =str(request.query_params.get('donViID'))
        try:
            query_string="SELECT * FROM HOCVIEN \
                            INNER JOIN PERSON ON HOCVIEN.PERSONID = PERSON.PersonID\
                            WHERE PERSON.DonViID IN (SELECT DonViID FROM DONVI WHERE DONVI.MaLop = %s OR DONVI.MaDaiDoi= %s OR DONVI.MaTieuDoan =%s)"            
            obj=generics_cursor.getDictFromQuery(query_string,[donViID,donViID,donViID],page=page,size=size)
            if obj is None:
                return Response(data={}, status=status.HTTP_204_NO_CONTENT)
        except:
            return Response(data={}, status=status.HTTP_500_INTERNAL_SERVER_ERROR)
        return Response(data=obj, status=status.HTTP_200_OK)

    @swagger_auto_schema(method='get', manual_parameters=[], responses=get_list_person_response)
    @action(methods=['GET'], detail=False, url_path='get-permission')
    def get_permission(self, request):
        roleId = request.user.roleID       
        return Response({"permission":int(roleId)}, status=status.HTTP_200_OK)

    @swagger_auto_schema(method='get', manual_parameters=[sw_MaHV,sw_TimeStart], responses=get_list_person_response)
    @action(methods=['GET'], detail=False, url_path='get-check-cam-trai')
    def get_check_cam_trai(self, request):
        maHV =request.query_params.get('maHV')
        timeStart = request.query_params.get('timeStart')       

        checkCamTrai,listReason = self.CheckQuyetDinhCamTrai(maHV,timeStart)
        print(checkCamTrai,listReason)
        if checkCamTrai:
            if len(listReason)==0:
                return Response(data={"result":False}, status=status.HTTP_500_INTERNAL_SERVER_ERROR)
            return Response(data={"result":False,"reason":listReason}, status=status.HTTP_200_OK)
      
        return Response(data={"result":True}, status=status.HTTP_200_OK)
    
