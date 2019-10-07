-- Generado por Oracle SQL Developer Data Modeler 19.2.0.182.1216
--   en:        2019-10-03 23:23:20 CLST
--   sitio:      Oracle Database 12c
--   tipo:      Oracle Database 12c



ALTER TABLE cliente DROP CONSTRAINT cliente_comuna_fk;

ALTER TABLE cliente DROP CONSTRAINT cliente_usuario_fk;

ALTER TABLE comuna DROP CONSTRAINT comuna_provincia_fk;

ALTER TABLE departamento DROP CONSTRAINT departamento_comuna_fk;

ALTER TABLE departamento_entorno DROP CONSTRAINT departamento_entorno_fk;

ALTER TABLE departamento_entorno DROP CONSTRAINT departamento_entorno_fkv2;

ALTER TABLE departamento DROP CONSTRAINT departamento_estado_fk;

ALTER TABLE departamento_inventario DROP CONSTRAINT departamento_inventario_fk;

ALTER TABLE departamento_inventario DROP CONSTRAINT departamento_inventario_fkv2;

ALTER TABLE departamento_servicio DROP CONSTRAINT departamento_servicio_fk;

ALTER TABLE departamento_servicio DROP CONSTRAINT departamento_servicio_fkv2;

ALTER TABLE detalle_reserva DROP CONSTRAINT detalle_reserva_paquete_fk;

ALTER TABLE detalle_reserva DROP CONSTRAINT detalle_reserva_reserva_fk;

ALTER TABLE empleado DROP CONSTRAINT empleado_comuna_fk;

ALTER TABLE empleado DROP CONSTRAINT empleado_sucursal_fk;

ALTER TABLE empleado DROP CONSTRAINT empleado_usuario_fk;

ALTER TABLE factura DROP CONSTRAINT factura_cliente_fk;

ALTER TABLE factura DROP CONSTRAINT factura_reserva_fk;

ALTER TABLE imagen DROP CONSTRAINT imagen_departamento_fk;

ALTER TABLE imagen DROP CONSTRAINT imagen_entorno_fk;

ALTER TABLE imagen DROP CONSTRAINT imagen_tour_fk;

ALTER TABLE paquete_producto DROP CONSTRAINT paquete_departamento_fk;

ALTER TABLE paquete_producto DROP CONSTRAINT paquete_tour_fk;

ALTER TABLE provincia DROP CONSTRAINT provincia_region_fk;

ALTER TABLE reserva DROP CONSTRAINT reserva_cliente_fk;

ALTER TABLE reserva DROP CONSTRAINT reserva_empleado_fk;

ALTER TABLE reserva DROP CONSTRAINT reserva_estados_fk;

ALTER TABLE reserva_pasajero DROP CONSTRAINT reserva_pasajero_pasajero_fk;

ALTER TABLE reserva_pasajero DROP CONSTRAINT reserva_pasajero_reserva_fk;

ALTER TABLE sucursal DROP CONSTRAINT sucursal_comuna_fk;

ALTER TABLE usuario DROP CONSTRAINT usuario_estado_fk;

ALTER TABLE usuario DROP CONSTRAINT usuario_tipo_usuario_fk;

ALTER TABLE valoracion DROP CONSTRAINT valoracion_cliente_fk;

ALTER TABLE valoracion DROP CONSTRAINT valoracion_departamento_fk;

DROP INDEX sucursal__idx;

DROP TABLE cliente CASCADE CONSTRAINTS;

DROP TABLE comuna CASCADE CONSTRAINTS;

DROP TABLE departamento CASCADE CONSTRAINTS;

DROP TABLE departamento_entorno CASCADE CONSTRAINTS;

DROP TABLE departamento_inventario CASCADE CONSTRAINTS;

DROP TABLE departamento_servicio CASCADE CONSTRAINTS;

DROP TABLE detalle_reserva CASCADE CONSTRAINTS;

DROP TABLE empleado CASCADE CONSTRAINTS;

DROP TABLE entorno CASCADE CONSTRAINTS;

DROP TABLE estado CASCADE CONSTRAINTS;

DROP TABLE factura CASCADE CONSTRAINTS;

DROP TABLE imagen CASCADE CONSTRAINTS;

DROP TABLE inventario CASCADE CONSTRAINTS;

DROP TABLE paquete_producto CASCADE CONSTRAINTS;

DROP TABLE pasajero CASCADE CONSTRAINTS;

DROP TABLE provincia CASCADE CONSTRAINTS;

DROP TABLE region CASCADE CONSTRAINTS;

DROP TABLE reserva CASCADE CONSTRAINTS;

DROP TABLE reserva_pasajero CASCADE CONSTRAINTS;

DROP TABLE servicio CASCADE CONSTRAINTS;

DROP TABLE sucursal CASCADE CONSTRAINTS;

DROP TABLE tipo_usuario CASCADE CONSTRAINTS;

DROP TABLE tour CASCADE CONSTRAINTS;

DROP TABLE usuario CASCADE CONSTRAINTS;

DROP TABLE valoracion CASCADE CONSTRAINTS;

CREATE TABLE cliente (
    run_cliente        VARCHAR2(9) NOT NULL,
    nombre             VARCHAR2(20),
    apellido_paterno   VARCHAR2(20),
    apellido_materno   VARCHAR2(20),
    telefono           VARCHAR2(12),
    email              VARCHAR2(50),
    fecha_nacimiento   DATE,
    direccion          VARCHAR2(50),
    usuario            VARCHAR2(50) NOT NULL,
    comuna_id          INTEGER NOT NULL
);

ALTER TABLE cliente ADD CONSTRAINT cliente_pk PRIMARY KEY ( run_cliente );

CREATE TABLE comuna (
    comuna_id       INTEGER NOT NULL,
    nombre_comuna   VARCHAR2(30),
    provincia_id    INTEGER NOT NULL
);

ALTER TABLE comuna ADD CONSTRAINT comuna_pk PRIMARY KEY ( comuna_id );

CREATE TABLE departamento (
    departamento_id   INTEGER NOT NULL,
    valor             INTEGER,
    nombre            VARCHAR2(50),
    direccion         VARCHAR2(50),
    superficie        VARCHAR2(300),
    condiciones_uso   VARCHAR2(300),
    fecha_creacion    DATE,
    comuna_id         INTEGER NOT NULL,
    estado_id         INTEGER NOT NULL
);

ALTER TABLE departamento ADD CONSTRAINT departamento_pk PRIMARY KEY ( departamento_id );

CREATE TABLE departamento_entorno (
    departamento_id   INTEGER NOT NULL,
    entorno_id        INTEGER NOT NULL
);

ALTER TABLE departamento_entorno ADD CONSTRAINT departamento_entorno_pk PRIMARY KEY ( departamento_id,
                                                                                      entorno_id );

CREATE TABLE departamento_inventario (
    departamento_id   INTEGER NOT NULL,
    inventario_id     INTEGER NOT NULL
);

ALTER TABLE departamento_inventario ADD CONSTRAINT departamento_inventario_pk PRIMARY KEY ( departamento_id,
                                                                                            inventario_id );

CREATE TABLE departamento_servicio (
    departamento_id   INTEGER NOT NULL,
    servicio_id       INTEGER NOT NULL
);

ALTER TABLE departamento_servicio ADD CONSTRAINT departamento_servicio_pk PRIMARY KEY ( departamento_id,
                                                                                        servicio_id );

CREATE TABLE detalle_reserva (
    detalle_reserva_id   INTEGER NOT NULL,
    reserva_id           INTEGER NOT NULL,
    paquete_id           INTEGER NOT NULL
);

ALTER TABLE detalle_reserva ADD CONSTRAINT detalle_reserva_pk PRIMARY KEY ( detalle_reserva_id );

CREATE TABLE empleado (
    run_empleado       VARCHAR2(9) NOT NULL,
    nombre             VARCHAR2(20),
    apellido_paterno   VARCHAR2(20),
    apellido_materno   VARCHAR2(20),
    telefono           VARCHAR2(13),
    email              VARCHAR2(50),
    direccion          VARCHAR2(50),
    fecha_nacimiento   DATE,
    cargo              VARCHAR2(20),
    usuario            VARCHAR2(50) NOT NULL,
    numero_sucursal    INTEGER NOT NULL,
    comuna_id          INTEGER NOT NULL
);

ALTER TABLE empleado ADD CONSTRAINT empleado_pk PRIMARY KEY ( run_empleado );

CREATE TABLE entorno (
    entorno_id   INTEGER NOT NULL,
    nombre       VARCHAR2(100),
    img          VARCHAR2(300)
);

ALTER TABLE entorno ADD CONSTRAINT entorno_pk PRIMARY KEY ( entorno_id );

CREATE TABLE estado (
    estado_id     INTEGER NOT NULL,
    entidad       VARCHAR2(20) NOT NULL,
    descripcion   VARCHAR2(20) NOT NULL
);

ALTER TABLE estado ADD CONSTRAINT estados_pk PRIMARY KEY ( estado_id );

CREATE TABLE factura (
    numero_factura   INTEGER NOT NULL,
    valor_neto       INTEGER,
    iva              FLOAT,
    total            INTEGER,
    reserva_id       INTEGER NOT NULL,
    run_cliente      VARCHAR2(9) NOT NULL
);

ALTER TABLE factura ADD CONSTRAINT factura_pk PRIMARY KEY ( numero_factura );

CREATE TABLE imagen (
    imagen_id         INTEGER NOT NULL,
    nombre_imagen     VARCHAR2(20),
    imagen_encode64   CLOB,
    tour_id           INTEGER NOT NULL,
    entorno_id        INTEGER NOT NULL,
    departamento_id   INTEGER NOT NULL
);

ALTER TABLE imagen ADD CONSTRAINT imagenes_pk PRIMARY KEY ( imagen_id );

CREATE TABLE inventario (
    inventario_id   INTEGER NOT NULL,
    nombre          NVARCHAR2(100),
    descripcion     NVARCHAR2(300)
);

ALTER TABLE inventario ADD CONSTRAINT inventario_pk PRIMARY KEY ( inventario_id );

CREATE TABLE paquete_producto (
    paquete_id        INTEGER NOT NULL,
    traslado          CHAR(1),
    tour_id           INTEGER NOT NULL,
    total             INTEGER,
    departamento_id   INTEGER NOT NULL
);

ALTER TABLE paquete_producto ADD CONSTRAINT paquete_pk PRIMARY KEY ( paquete_id );

CREATE TABLE pasajero (
    run_pasajero       VARCHAR2(9) NOT NULL,
    nombre             VARCHAR2(20),
    apellido_paterno   VARCHAR2(20),
    apellido_materno   VARCHAR2(20),
    telefono           VARCHAR2(13),
    email              VARCHAR2(50),
    fecha_nacimiento   DATE,
    menor_edad         NUMBER
);

ALTER TABLE pasajero ADD CONSTRAINT pasajero_pk PRIMARY KEY ( run_pasajero );

CREATE TABLE provincia (
    provincia_id       INTEGER NOT NULL,
    nombre_provincia   VARCHAR2(30),
    region_id          INTEGER NOT NULL
);

ALTER TABLE provincia ADD CONSTRAINT provincia_pk PRIMARY KEY ( provincia_id );

CREATE TABLE region (
    region_id         INTEGER NOT NULL,
    nombre_region     VARCHAR2(50),
    region_cardinal   VARCHAR2(50)
);

ALTER TABLE region ADD CONSTRAINT region_pk PRIMARY KEY ( region_id );

CREATE TABLE reserva (
    reserva_id                 INTEGER NOT NULL,
    estado_id                  INTEGER NOT NULL,
    fecha_hora_reserva         DATE,
    fecha_hora_actualizacion   DATE,
    run_cliente                VARCHAR2(9) NOT NULL,
    run_empleado               VARCHAR2(9) NOT NULL
);

ALTER TABLE reserva ADD CONSTRAINT reserva_pk PRIMARY KEY ( reserva_id );

CREATE TABLE reserva_pasajero (
    reserva_id     INTEGER NOT NULL,
    run_pasajero   VARCHAR2(9) NOT NULL
);

ALTER TABLE reserva_pasajero ADD CONSTRAINT reserva_pasajero_pk PRIMARY KEY ( reserva_id,
                                                                              run_pasajero );

CREATE TABLE servicio (
    servicio_id   INTEGER NOT NULL,
    nombre        VARCHAR2(100),
    costo         INTEGER,
    descripcion   VARCHAR2(100)
);

ALTER TABLE servicio ADD CONSTRAINT servicio_depto_pk PRIMARY KEY ( servicio_id );

CREATE TABLE sucursal (
    numero_sucursal   INTEGER NOT NULL,
    direccion         VARCHAR2(50),
    telefono          VARCHAR2(13),
    comuna_id         INTEGER NOT NULL
);

CREATE UNIQUE INDEX sucursal__idx ON
    sucursal (
        numero_sucursal
    ASC );

ALTER TABLE sucursal ADD CONSTRAINT sucursal_pk PRIMARY KEY ( numero_sucursal );

CREATE TABLE tipo_usuario (
    codigo        VARCHAR2(5) NOT NULL,
    descripcion   VARCHAR2(10)
);

COMMENT ON COLUMN tipo_usuario.codigo IS
    'dd comment';

ALTER TABLE tipo_usuario ADD CONSTRAINT tipo_usuario_pk PRIMARY KEY ( codigo );

CREATE TABLE tour (
    tour_id           INTEGER NOT NULL,
    valor_tour        INTEGER,
    itinerario_tour   VARCHAR2(300),
    nombre_tour       VARCHAR2(20)
);

ALTER TABLE tour ADD CONSTRAINT tour_pk PRIMARY KEY ( tour_id );

CREATE TABLE usuario (
    usuario               VARCHAR2(50) NOT NULL,
    contrasena            VARCHAR2(30),
    tipo_usuario_codigo   VARCHAR2(5) NOT NULL,
    estado_id             INTEGER NOT NULL
);

ALTER TABLE usuario ADD CONSTRAINT usuario_pk PRIMARY KEY ( usuario );

CREATE TABLE valoracion (
    valoracion_id     INTEGER NOT NULL,
    ranking           INTEGER,
    departamento_id   INTEGER NOT NULL,
    run_cliente       VARCHAR2(9) NOT NULL
);

ALTER TABLE valoracion ADD CONSTRAINT valoracion_pk PRIMARY KEY ( valoracion_id );

ALTER TABLE cliente
    ADD CONSTRAINT cliente_comuna_fk FOREIGN KEY ( comuna_id )
        REFERENCES comuna ( comuna_id );

ALTER TABLE cliente
    ADD CONSTRAINT cliente_usuario_fk FOREIGN KEY ( usuario )
        REFERENCES usuario ( usuario );

ALTER TABLE comuna
    ADD CONSTRAINT comuna_provincia_fk FOREIGN KEY ( provincia_id )
        REFERENCES provincia ( provincia_id );

ALTER TABLE departamento
    ADD CONSTRAINT departamento_comuna_fk FOREIGN KEY ( comuna_id )
        REFERENCES comuna ( comuna_id );

ALTER TABLE departamento_entorno
    ADD CONSTRAINT departamento_entorno_fk FOREIGN KEY ( departamento_id )
        REFERENCES departamento ( departamento_id );

ALTER TABLE departamento_entorno
    ADD CONSTRAINT departamento_entorno_fkv2 FOREIGN KEY ( entorno_id )
        REFERENCES entorno ( entorno_id );

ALTER TABLE departamento
    ADD CONSTRAINT departamento_estado_fk FOREIGN KEY ( estado_id )
        REFERENCES estado ( estado_id );

ALTER TABLE departamento_inventario
    ADD CONSTRAINT departamento_inventario_fk FOREIGN KEY ( departamento_id )
        REFERENCES departamento ( departamento_id );

ALTER TABLE departamento_inventario
    ADD CONSTRAINT departamento_inventario_fkv2 FOREIGN KEY ( inventario_id )
        REFERENCES inventario ( inventario_id );

ALTER TABLE departamento_servicio
    ADD CONSTRAINT departamento_servicio_fk FOREIGN KEY ( departamento_id )
        REFERENCES departamento ( departamento_id );

ALTER TABLE departamento_servicio
    ADD CONSTRAINT departamento_servicio_fkv2 FOREIGN KEY ( servicio_id )
        REFERENCES servicio ( servicio_id );

ALTER TABLE detalle_reserva
    ADD CONSTRAINT detalle_reserva_paquete_fk FOREIGN KEY ( paquete_id )
        REFERENCES paquete_producto ( paquete_id );

ALTER TABLE detalle_reserva
    ADD CONSTRAINT detalle_reserva_reserva_fk FOREIGN KEY ( reserva_id )
        REFERENCES reserva ( reserva_id );

ALTER TABLE empleado
    ADD CONSTRAINT empleado_comuna_fk FOREIGN KEY ( comuna_id )
        REFERENCES comuna ( comuna_id );

ALTER TABLE empleado
    ADD CONSTRAINT empleado_sucursal_fk FOREIGN KEY ( numero_sucursal )
        REFERENCES sucursal ( numero_sucursal );

ALTER TABLE empleado
    ADD CONSTRAINT empleado_usuario_fk FOREIGN KEY ( usuario )
        REFERENCES usuario ( usuario );

ALTER TABLE factura
    ADD CONSTRAINT factura_cliente_fk FOREIGN KEY ( run_cliente )
        REFERENCES cliente ( run_cliente );

ALTER TABLE factura
    ADD CONSTRAINT factura_reserva_fk FOREIGN KEY ( reserva_id )
        REFERENCES reserva ( reserva_id );

ALTER TABLE imagen
    ADD CONSTRAINT imagen_departamento_fk FOREIGN KEY ( departamento_id )
        REFERENCES departamento ( departamento_id );

ALTER TABLE imagen
    ADD CONSTRAINT imagen_entorno_fk FOREIGN KEY ( entorno_id )
        REFERENCES entorno ( entorno_id );

ALTER TABLE imagen
    ADD CONSTRAINT imagen_tour_fk FOREIGN KEY ( tour_id )
        REFERENCES tour ( tour_id );

ALTER TABLE paquete_producto
    ADD CONSTRAINT paquete_departamento_fk FOREIGN KEY ( departamento_id )
        REFERENCES departamento ( departamento_id );

ALTER TABLE paquete_producto
    ADD CONSTRAINT paquete_tour_fk FOREIGN KEY ( tour_id )
        REFERENCES tour ( tour_id );

ALTER TABLE provincia
    ADD CONSTRAINT provincia_region_fk FOREIGN KEY ( region_id )
        REFERENCES region ( region_id );

ALTER TABLE reserva
    ADD CONSTRAINT reserva_cliente_fk FOREIGN KEY ( run_cliente )
        REFERENCES cliente ( run_cliente );

ALTER TABLE reserva
    ADD CONSTRAINT reserva_empleado_fk FOREIGN KEY ( run_empleado )
        REFERENCES empleado ( run_empleado );

ALTER TABLE reserva
    ADD CONSTRAINT reserva_estados_fk FOREIGN KEY ( estado_id )
        REFERENCES estado ( estado_id );

ALTER TABLE reserva_pasajero
    ADD CONSTRAINT reserva_pasajero_pasajero_fk FOREIGN KEY ( run_pasajero )
        REFERENCES pasajero ( run_pasajero );

ALTER TABLE reserva_pasajero
    ADD CONSTRAINT reserva_pasajero_reserva_fk FOREIGN KEY ( reserva_id )
        REFERENCES reserva ( reserva_id );

ALTER TABLE sucursal
    ADD CONSTRAINT sucursal_comuna_fk FOREIGN KEY ( comuna_id )
        REFERENCES comuna ( comuna_id );

ALTER TABLE usuario
    ADD CONSTRAINT usuario_estado_fk FOREIGN KEY ( estado_id )
        REFERENCES estado ( estado_id );

ALTER TABLE usuario
    ADD CONSTRAINT usuario_tipo_usuario_fk FOREIGN KEY ( tipo_usuario_codigo )
        REFERENCES tipo_usuario ( codigo );

ALTER TABLE valoracion
    ADD CONSTRAINT valoracion_cliente_fk FOREIGN KEY ( run_cliente )
        REFERENCES cliente ( run_cliente );

ALTER TABLE valoracion
    ADD CONSTRAINT valoracion_departamento_fk FOREIGN KEY ( departamento_id )
        REFERENCES departamento ( departamento_id );



-- Informe de Resumen de Oracle SQL Developer Data Modeler: 
-- 
-- CREATE TABLE                            25
-- CREATE INDEX                             1
-- ALTER TABLE                             93
-- CREATE VIEW                              0
-- ALTER VIEW                               0
-- CREATE PACKAGE                           0
-- CREATE PACKAGE BODY                      0
-- CREATE PROCEDURE                         0
-- CREATE FUNCTION                          0
-- CREATE TRIGGER                           0
-- ALTER TRIGGER                            0
-- CREATE COLLECTION TYPE                   0
-- CREATE STRUCTURED TYPE                   0
-- CREATE STRUCTURED TYPE BODY              0
-- CREATE CLUSTER                           0
-- CREATE CONTEXT                           0
-- CREATE DATABASE                          0
-- CREATE DIMENSION                         0
-- CREATE DIRECTORY                         0
-- CREATE DISK GROUP                        0
-- CREATE ROLE                              0
-- CREATE ROLLBACK SEGMENT                  0
-- CREATE SEQUENCE                          0
-- CREATE MATERIALIZED VIEW                 0
-- CREATE MATERIALIZED VIEW LOG             0
-- CREATE SYNONYM                           0
-- CREATE TABLESPACE                        0
-- CREATE USER                              0
-- 
-- DROP TABLESPACE                          0
-- DROP DATABASE                            0
-- 
-- REDACTION POLICY                         0
-- TSDP POLICY                              0
-- 
-- ORDS DROP SCHEMA                         0
-- ORDS ENABLE SCHEMA                       0
-- ORDS ENABLE OBJECT                       0
-- 
-- ERRORS                                   0
-- WARNINGS                                 0
