from rest_framework.views import APIView
from rest_framework.response import Response
from rest_framework.permissions import IsAuthenticated

from rest_framework import status
from rest_framework import serializers
from customUsers.models import CustomUser
from roles.models import Role

class RoleSerializer(serializers.ModelSerializer):

    class Meta:
        model = Role
        fields = ()

    def create(self, validated_data):
        # password = validated_data.pop('password')
        role = Role(**validated_data)
        role.save()

        return role

class Role(APIView):
    def get(self, request, role_id):
        try:
            role = Role.objects.get(id=role_id)
            serializer = RoleSerializer(role)

            return Response(serializer.data, status=status.HTTP_200_OK)
        except CustomUser.DoesNotExist:
            return Response({'error': 'Role not found'}, status=status.HTTP_404_NOT_FOUND)
        except Exception as e:
            print(e)
            return Response({'error': str(e)}, status=status.HTTP_500_INTERNAL_SERVER_ERROR)

class RoleUser(APIView):
    def put(self, request, role_id, user_id):
        try:
            role = Role.objects.get(id=role_id)
            user = CustomUser.objects.get(id=user_id)

            role.users.add(user)
            role.save()

            return Response({'message': 'User added to role'}, status=status.HTTP_200_OK)
        except Role.DoesNotExist:
            return Response({'error': 'Role not found'}, status=status.HTTP_404_NOT_FOUND)
        except CustomUser.DoesNotExist:
            return Response({'error': 'User not found'}, status=status.HTTP_404_NOT_FOUND)
        except Exception as e:
            print(e)
            return Response({'error': str(e)}, status=status.HTTP_500_INTERNAL_SERVER_ERROR)

    def delete(self, request, role_id, user_id):
        try:
            role = Role.objects.get(id=role_id)
            user = CustomUser.objects.get(id=user_id)

            role.users.remove(user)
            role.save()

            return Response({'message': 'User removed from role'}, status=status.HTTP_200_OK)
        except Role.DoesNotExist:
            return Response({'error': 'Role not found'}, status=status.HTTP_404_NOT_FOUND)
        except CustomUser.DoesNotExist:
            return Response({'error': 'User not found'}, status=status.HTTP_404_NOT_FOUND)
        except Exception as e:
            print(e)
            return Response({'error': str(e)}, status=status.HTTP_500_INTERNAL_SERVER_ERROR)