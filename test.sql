PGDMP  0    -                |            test    17.2    17.2     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false            �           1262    16400    test    DATABASE     x   CREATE DATABASE test WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE test;
                     postgres    false            �            1259    16410    task    TABLE        CREATE TABLE public.task (
    id integer NOT NULL,
    name character varying(255) NOT NULL,
    status character varying(50) NOT NULL,
    start_time timestamp without time zone NOT NULL,
    end_time timestamp without time zone,
    description text
);
    DROP TABLE public.task;
       public         heap r       postgres    false            �            1259    16409    task_id_seq    SEQUENCE     �   CREATE SEQUENCE public.task_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 "   DROP SEQUENCE public.task_id_seq;
       public               postgres    false    219            �           0    0    task_id_seq    SEQUENCE OWNED BY     ;   ALTER SEQUENCE public.task_id_seq OWNED BY public.task.id;
          public               postgres    false    218            �            1259    16401    user    TABLE     �   CREATE TABLE public."user" (
    name text NOT NULL,
    id integer NOT NULL,
    status text,
    created_at timestamp without time zone DEFAULT now()
);
    DROP TABLE public."user";
       public         heap r       postgres    false            \           2604    16413    task id    DEFAULT     b   ALTER TABLE ONLY public.task ALTER COLUMN id SET DEFAULT nextval('public.task_id_seq'::regclass);
 6   ALTER TABLE public.task ALTER COLUMN id DROP DEFAULT;
       public               postgres    false    219    218    219            �          0    16410    task 
   TABLE DATA           S   COPY public.task (id, name, status, start_time, end_time, description) FROM stdin;
    public               postgres    false    219          �          0    16401    user 
   TABLE DATA           >   COPY public."user" (name, id, status, created_at) FROM stdin;
    public               postgres    false    217   3       �           0    0    task_id_seq    SEQUENCE SET     :   SELECT pg_catalog.setval('public.task_id_seq', 1, false);
          public               postgres    false    218            `           2606    16417    task task_pkey 
   CONSTRAINT     L   ALTER TABLE ONLY public.task
    ADD CONSTRAINT task_pkey PRIMARY KEY (id);
 8   ALTER TABLE ONLY public.task DROP CONSTRAINT task_pkey;
       public                 postgres    false    219            ^           2606    16407    user user_pkey 
   CONSTRAINT     N   ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_pkey PRIMARY KEY (id);
 :   ALTER TABLE ONLY public."user" DROP CONSTRAINT user_pkey;
       public                 postgres    false    217            �      x������ � �      �   @   x�3�4估I�¾�.츰�{��N##]C#]#CC+S#+#c=S#CScc�=... ϯ!     