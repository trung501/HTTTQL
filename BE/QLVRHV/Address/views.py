
from rest_framework import viewsets
from django.db import connection
from rest_framework.response import Response
from rest_framework.decorators import action
from drf_yasg.utils import swagger_auto_schema
from drf_yasg import openapi
from rest_framework import status
from rest_framework import pagination
from Common import generics_cursor, custom_permission

class AddressPermission(custom_permission.CustomPermissions):
    def __init__(self):
        super().__init__()

    # def get_allowed_methods(self, username):
    #     ## query in database here
    #     username = username
    #     return ['GET']


# Create your views here.
class AddressViewSet(viewsets.ViewSet):
    """
    Interact with UserCam
    """
    
    permission_classes = [AddressPermission]

    # all swagger's parameters should be defined here 
    sw_page = openapi.Parameter(
        name='page', type=openapi.TYPE_STRING, description="Page number", in_=openapi.IN_QUERY)
    sw_size = openapi.Parameter(
        name='size', type=openapi.TYPE_STRING, description="Number of results to return per page", in_=openapi.IN_QUERY)
    sw_DonViID = openapi.Parameter(
        name='donViID', type=openapi.TYPE_STRING, description="DonViID", in_=openapi.IN_QUERY)
    sw_UserID = openapi.Parameter(
        name='UserID', type=openapi.TYPE_STRING, description="UserID", in_=openapi.IN_QUERY)

    get_list_don_vi_response = {
        status.HTTP_500_INTERNAL_SERVER_ERROR: 'INTERNAL_SERVER_ERROR',
        status.HTTP_204_NO_CONTENT: 'NO_CONTENT',
        status.HTTP_200_OK: 'JSON',
    }

    @swagger_auto_schema(method='get', manual_parameters=[sw_page, sw_size], responses=get_list_don_vi_response)
    @action(methods=['GET'], detail=False, url_path='get-list-don-vi')
    def get_list_don_vi(self, request):
        page = request.query_params.get('page')
        size = request.query_params.get('size')
        # donViID = request.query_params.get('donViID')
        UserID = request.query_params.get('UserID')
        maDV = 
        roleID = 
        select_string = ""
        join_string = ""
        condition_string=""
        if UserID is not None:
            join_string = " account_USER inner join person on person.personID = account_USER.personID"\
                          " inner join donvi AS DV1 on DV1.donviid = person.donviID"\
            condition_string = "account_user.personID = %s"
            if roleID == 4 or roleID ==0:
               select_string ="DONVI.DONVIID, TIEUDOAN.MATD, TIEUDOAN.TENTD"
               join_string = "donvi inner join TIEUDOAN on DONVI.MATIEUDOAN = TIEUDOAN.MATD"
               condition_string = "DONVI.MADAIDOI is null"
            if roleID == 3:
               select_string ="DV2.DONVIID, DAIDOI.MADD, DAIDOI.TENDD"
               join_string = join_string +"inner join donvi AS DV2 on DV2.MaTieuDoan= DV1.MaTieuDoan"\
                                          "inner join DAIDOI on DV2.MADAIDOI = DAIDOI.MADD"
               condition_string = "DV2.MALOP is null"
            if roleID == 2:
               select_string ="DV2.DONVIID, LOP.MALOP, LOP.TENLOP"
               join_string = join_string +"inner join donvi AS DV2 on DV2.MaDaiDoi= DV1.MaDaiDoi"\
                                           "inner join LOP on DV2.MaLop = LOP.MaLop"
        else:
            if maDV is not None:
                if maDV[0:2] =="TD":
                    select_string = "DONVI.DONVIID, DAIDOI.MADD, DAIDOI.TENDD"
                    join_string ="TIEUDOAN INNER JOIN DONVI on TIEUDOAN.MATD = DONVI.MATIEUDOAN"\
                                 " inner join DAIDOI on DONVI.DONVIID = DAIDOI.DONVIID"
                    condition_string = "TIEUDOAN.MATD = %s and DONVI.TIEUDOAN = %s and DONVI.MALOP IS null"
                if maDV[0:2] =="DD":
                    select_string = "DONVI.DONVIID, LOP.MALOP, LOP.TENLOP"
                    join_string ="DAIDOI inner join DONVI on DAIDOI.MADD = DONVI.MADAIDOI"\
                                 " inner join LOP on DONVI.MALOP = LOP.MALOP"
                    condition_string = "DAIDOI.MADD = %s and DONVI.MADAIDOI = %s"
        query_string =  f"SELECT {select_string} FROM {join_string} WHERE {condition_string} "                    

                


            
        
        # try:
            

        #     param =[]
        #     query_String =  f"SELECT DISTINCT USER_LIST.CODE, USER_LIST.USERNAME, USER_LIST.SUBJECT_NAME NAME, ADDRESS_DETAIL, EMAIL, PHONE "\
        #                     "FROM USER_LIST "\
        #                     "JOIN USER_CAM ON USER_LIST.USERNAME = USER_CAM.USERNAME "
        #     print(query_String)
        #     with connection.cursor() as cursor:
        #         obj = generics_cursor.getDictFromQuery(cursor, query_StGUARDSMAN_ROLEring, param, page, size)
        #     if obj is None:
        #         return Response(data={}, status=status.HTTP_204_NO_CONTENT)
        # except:
        #         return Response(data={}, status=status.HTTP_500_INTERNAL_SERVER_ERROR) 
        # return Response(data=obj, status=status.HTTP_200_OK)