using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data
{
    public partial class GuestifyDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public GuestifyDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Ingredient> Ingredients { get; set; }

        public virtual DbSet<IngredientCategory> IngredientCategories { get; set; }

        public virtual DbSet<ItemCategory> ItemCategories { get; set; }

        public virtual DbSet<ItemIngredient> ItemIngredients { get; set; }

        public virtual DbSet<MenuItem> MenuItems { get; set; }

        public virtual DbSet<MenuItemCategory> MenuItemCategories { get; set; }

        public virtual DbSet<MenuItemPromotion> MenuItemPromotions { get; set; }

        public virtual DbSet<Notification> Notifications { get; set; }

        public virtual DbSet<OrderCart> OrderCarts { get; set; }

        public virtual DbSet<OrderCartItem> OrderCartItems { get; set; }

        public virtual DbSet<OrderInfo> OrderInfos { get; set; }

        public virtual DbSet<OrderItem> OrderItems { get; set; }

        public virtual DbSet<OrderLine> OrderLines { get; set; }

        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

        public virtual DbSet<OrderType> OrderTypes { get; set; }

        public virtual DbSet<Permission> Permissions { get; set; }

        public virtual DbSet<Promocode> Promocodes { get; set; }

        public virtual DbSet<Promotion> Promotions { get; set; }

        public virtual DbSet<Reservation> Reservations { get; set; }

        public virtual DbSet<ReviewCriterion> ReviewCriteria { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<RolePermission> RolePermissions { get; set; }

        public virtual DbSet<Staff> Staff { get; set; }

        public virtual DbSet<StaffNotification> StaffNotifications { get; set; }

        public virtual DbSet<StaffRefreshToken> StaffRefreshTokens { get; set; }

        public virtual DbSet<StaffRole> StaffRoles { get; set; }

        public virtual DbSet<Supplier> Suppliers { get; set; }

        public virtual DbSet<SupplierInfo> SupplierInfos { get; set; }

        public virtual DbSet<TableInfo> TableInfos { get; set; }

        public virtual DbSet<TableReservation> TableReservations { get; set; }

        public virtual DbSet<TableStatus> TableStatuses { get; set; }

        public virtual DbSet<UserAddress> UserAddresses { get; set; }

        public virtual DbSet<UserInfo> UserInfos { get; set; }

        public virtual DbSet<UserNotificaiton> UserNotificaitons { get; set; }

        public virtual DbSet<UserPromocode> UserPromocodes { get; set; }

        public virtual DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        public virtual DbSet<UserReview> UserReviews { get; set; }

        public virtual DbSet<UserReviewCriterion> UserReviewCriteria { get; set; }

        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Database"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("address_pkey");

                entity.ToTable("address");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.ApartmentNumber)
                    .HasMaxLength(10)
                    .HasColumnName("apartment_number");
                entity.Property(e => e.BuildingNumber)
                    .HasMaxLength(10)
                    .HasColumnName("building_number");
                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");
                entity.Property(e => e.Comment)
                    .HasMaxLength(255)
                    .HasColumnName("comment");
                entity.Property(e => e.HouseNumber)
                    .HasMaxLength(10)
                    .HasColumnName("house_number");
                entity.Property(e => e.Street)
                    .HasMaxLength(50)
                    .HasColumnName("street");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ingredient_pkey");

                entity.ToTable("ingredient");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CategoryId).HasColumnName("category_id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
                entity.Property(e => e.Quantity)
                    .HasPrecision(10, 2)
                    .HasColumnName("quantity");
                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.HasOne(d => d.Category).WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("ingredient_category_id_fkey");

                entity.HasOne(d => d.Supplier).WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("ingredient_supplier_id_fkey");
            });

            modelBuilder.Entity<IngredientCategory>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ingredient_category_pkey");

                entity.ToTable("ingredient_category");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
                entity.Property(e => e.ParentCateghoryId).HasColumnName("parent_categhory_id");

                entity.HasOne(d => d.ParentCateghory).WithMany(p => p.InverseParentCateghory)
                    .HasForeignKey(d => d.ParentCateghoryId)
                    .HasConstraintName("ingredient_category_parent_categhory_id_fkey");
            });

            modelBuilder.Entity<ItemCategory>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("item_category_pkey");

                entity.ToTable("item_category");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ItemIngredient>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("item_ingredient");

                entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");
                entity.Property(e => e.ItemId).HasColumnName("item_id");
                entity.Property(e => e.Quantity)
                    .HasPrecision(10, 2)
                    .HasColumnName("quantity");

                entity.HasOne(d => d.Ingredient).WithMany()
                    .HasForeignKey(d => d.IngredientId)
                    .HasConstraintName("item_ingredient_ingredient_id_fkey");

                entity.HasOne(d => d.Item).WithMany()
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("item_ingredient_item_id_fkey");
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("menu_item_pkey");

                entity.ToTable("menu_item");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");
                entity.Property(e => e.ImagePath)
                    .HasMaxLength(255)
                    .HasColumnName("image_path");
                entity.Property(e => e.IsAlcohol).HasColumnName("is_alcohol");
                entity.Property(e => e.IsVegan).HasColumnName("is_vegan");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
                entity.Property(e => e.Price)
                    .HasPrecision(10, 2)
                    .HasColumnName("price");
            });

            modelBuilder.Entity<MenuItemCategory>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("menu_item_category");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");
                entity.Property(e => e.IsDefault).HasColumnName("is_default");
                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.HasOne(d => d.Category).WithMany()
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("menu_item_category_category_id_fkey");

                entity.HasOne(d => d.Item).WithMany()
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("menu_item_category_item_id_fkey");
            });

            modelBuilder.Entity<MenuItemPromotion>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("menu_item_promotion");

                entity.Property(e => e.ItemId).HasColumnName("item_id");
                entity.Property(e => e.PromotionId).HasColumnName("promotion_id");

                entity.HasOne(d => d.Item).WithMany()
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("menu_item_promotion_item_id_fkey");

                entity.HasOne(d => d.Promotion).WithMany()
                    .HasForeignKey(d => d.PromotionId)
                    .HasConstraintName("menu_item_promotion_promotion_id_fkey");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("notification_pkey");

                entity.ToTable("notification");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("created_at");
                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");
                entity.Property(e => e.IsRead).HasColumnName("is_read");
                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("title");
                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<OrderCart>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("order_cart_pkey");

                entity.ToTable("order_cart");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User).WithMany(p => p.OrderCarts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("order_cart_user_id_fkey");
            });

            modelBuilder.Entity<OrderCartItem>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("order_cart_item");

                entity.Property(e => e.CartId).HasColumnName("cart_id");
                entity.Property(e => e.MenuItemId).HasColumnName("menu_item_id");
                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Cart).WithMany()
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("order_cart_item_cart_id_fkey");

                entity.HasOne(d => d.MenuItem).WithMany()
                    .HasForeignKey(d => d.MenuItemId)
                    .HasConstraintName("order_cart_item_menu_item_id_fkey");
            });

            modelBuilder.Entity<OrderInfo>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("order_info_pkey");

                entity.ToTable("order_info");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Comment)
                    .HasMaxLength(255)
                    .HasColumnName("comment");
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("created_at");
                entity.Property(e => e.FinishedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("finished_at");
                entity.Property(e => e.NumberOfGuest).HasColumnName("number_of_guest");
                entity.Property(e => e.OrderStatusId).HasColumnName("order_status_id");
                entity.Property(e => e.OrderTypeId).HasColumnName("order_type_id");
                entity.Property(e => e.PromocodeId).HasColumnName("promocode_id");
                entity.Property(e => e.TableId).HasColumnName("table_id");
                entity.Property(e => e.TotalSum)
                    .HasPrecision(10, 2)
                    .HasColumnName("total_sum");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.WaiterId).HasColumnName("waiter_id");

                entity.HasOne(d => d.OrderStatus).WithMany(p => p.OrderInfos)
                    .HasForeignKey(d => d.OrderStatusId)
                    .HasConstraintName("order_info_order_status_id_fkey");

                entity.HasOne(d => d.OrderType).WithMany(p => p.OrderInfos)
                    .HasForeignKey(d => d.OrderTypeId)
                    .HasConstraintName("order_info_order_type_id_fkey");

                entity.HasOne(d => d.Promocode).WithMany(p => p.OrderInfos)
                    .HasForeignKey(d => d.PromocodeId)
                    .HasConstraintName("order_info_promocode_id_fkey");

                entity.HasOne(d => d.Table).WithMany(p => p.OrderInfos)
                    .HasForeignKey(d => d.TableId)
                    .HasConstraintName("order_info_table_id_fkey");

                entity.HasOne(d => d.User).WithMany(p => p.OrderInfos)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("order_info_user_id_fkey");

                entity.HasOne(d => d.Waiter).WithMany(p => p.OrderInfos)
                    .HasForeignKey(d => d.WaiterId)
                    .HasConstraintName("order_info_waiter_id_fkey");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("order_item_pkey");

                entity.ToTable("order_item");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.ChefId).HasColumnName("chef_id");
                entity.Property(e => e.IsReady).HasColumnName("is_ready");
                entity.Property(e => e.MenuItemId).HasColumnName("menu_item_id");
                entity.Property(e => e.OrderInfoId).HasColumnName("order_info_id");
                entity.Property(e => e.Price)
                    .HasPrecision(10, 2)
                    .HasColumnName("price");
                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Chef).WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ChefId)
                    .HasConstraintName("order_item_chef_id_fkey");

                entity.HasOne(d => d.MenuItem).WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.MenuItemId)
                    .HasConstraintName("order_item_menu_item_id_fkey");

                entity.HasOne(d => d.OrderInfo).WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderInfoId)
                    .HasConstraintName("order_item_order_info_id_fkey");
            });

            modelBuilder.Entity<OrderLine>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("order_line_pkey");

                entity.ToTable("order_line");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.IsShow).HasColumnName("is_show");
                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.HasOne(d => d.Order).WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("order_line_order_id_fkey");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("order_status_pkey");

                entity.ToTable("order_status");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<OrderType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("order_type_pkey");
                entity.ToTable("order_type");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("permission_pkey");

                entity.ToTable("permission");

                entity.HasIndex(e => e.Name, "permission_name_key").IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Promocode>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("promocode_pkey");

                entity.ToTable("promocode");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .HasColumnName("code");
                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");
                entity.Property(e => e.Discount)
                    .HasPrecision(10, 2)
                    .HasColumnName("discount");
                entity.Property(e => e.EndDate).HasColumnName("end_date");
                entity.Property(e => e.IsUsed)
                    .HasDefaultValue(false)
                    .HasColumnName("is_used");
                entity.Property(e => e.MaxDiscount)
                    .HasPrecision(10, 2)
                    .HasColumnName("max_discount");
                entity.Property(e => e.StartDate).HasColumnName("start_date");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("promotion_pkey");

                entity.ToTable("promotion");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");
                entity.Property(e => e.Discount)
                    .HasPrecision(10, 2)
                    .HasColumnName("discount");
                entity.Property(e => e.EndDate).HasColumnName("end_date");
                entity.Property(e => e.IsActive).HasColumnName("is_active");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
                entity.Property(e => e.StartDate).HasColumnName("start_date");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("reservation_pkey");

                entity.ToTable("reservation");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.EndDate).HasColumnName("end_date");
                entity.Property(e => e.Guests).HasColumnName("guests");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
                entity.Property(e => e.StartDate).HasColumnName("start_date");
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User).WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("reservation_user_id_fkey");
            });

            modelBuilder.Entity<ReviewCriterion>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("review_criteria");

                entity.Property(e => e.UserReviewCriteriaId).HasColumnName("user_review_criteria_id");
                entity.Property(e => e.UserRevoewId).HasColumnName("user_revoew_id");

                entity.HasOne(d => d.UserReviewCriteria).WithMany()
                    .HasForeignKey(d => d.UserReviewCriteriaId)
                    .HasConstraintName("review_criteria_user_review_criteria_id_fkey");

                entity.HasOne(d => d.UserRevoew).WithMany()
                    .HasForeignKey(d => d.UserRevoewId)
                    .HasConstraintName("review_criteria_user_revoew_id_fkey");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("role_pkey");

                entity.ToTable("role");

                entity.HasIndex(e => e.RoleName, "role_role_name_key").IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");
                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("role_permission_pkey");

                entity.ToTable("role_permission");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.PermissionId).HasColumnName("permission_id");
                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("role_permission_permission_id_fkey");

                entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("role_permission_role_id_fkey");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("staff_pkey");

                entity.ToTable("staff");

                entity.HasIndex(e => e.EmailAddress, "staff_email_address_key").IsUnique();

                entity.HasIndex(e => e.PhoneNumber, "staff_phone_number_key").IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.AddressId).HasColumnName("address_id");
                entity.Property(e => e.DateOfEmployment).HasColumnName("date_of_employment");
                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .HasColumnName("email_address");
                entity.Property(e => e.FormAtEmployment)
                    .HasMaxLength(50)
                    .HasColumnName("form_at_employment");
                entity.Property(e => e.HashedPassword)
                    .HasMaxLength(255)
                    .HasColumnName("hashed_password");
                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .HasColumnName("lastname");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .HasColumnName("phone_number");
                entity.Property(e => e.Salt)
                    .HasMaxLength(1024)
                    .HasColumnName("salt");
                entity.Property(e => e.Sex)
                    .HasMaxLength(15)
                    .HasColumnName("sex");
                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");
                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .HasColumnName("surname");

                entity.HasOne(d => d.Address).WithMany(p => p.Staff)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("staff_address_id_fkey");
            });

            modelBuilder.Entity<StaffNotification>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("staff_notification");

                entity.Property(e => e.NotificationId).HasColumnName("notification_id");
                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.HasOne(d => d.Notification).WithMany()
                    .HasForeignKey(d => d.NotificationId)
                    .HasConstraintName("staff_notification_notification_id_fkey");

                entity.HasOne(d => d.Staff).WithMany()
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("staff_notification_staff_id_fkey");
            });

            modelBuilder.Entity<StaffRefreshToken>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("staff_refresh_token_pkey");

                entity.ToTable("staff_refresh_token");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("created_at");
                entity.Property(e => e.ExpiresAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("expires_at");
                entity.Property(e => e.StaffId).HasColumnName("staff_id");
                entity.Property(e => e.Token)
                    .HasMaxLength(255)
                    .HasColumnName("token");

                entity.HasOne(d => d.Staff).WithMany(p => p.StaffRefreshTokens)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("staff_refresh_token_staff_id_fkey");
            });

            modelBuilder.Entity<StaffRole>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("staff_role_pkey");

                entity.ToTable("staff_role");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.RoleId).HasColumnName("role_id");
                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.HasOne(d => d.Role).WithMany(p => p.StaffRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("staff_role_role_id_fkey");

                entity.HasOne(d => d.Staff).WithMany(p => p.StaffRoles)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("staff_role_staff_id_fkey");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("supplier_pkey");

                entity.ToTable("supplier");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .HasColumnName("company_name");
                entity.Property(e => e.ContactInfoId).HasColumnName("contact_info_id");

                entity.HasOne(d => d.ContactInfo).WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.ContactInfoId)
                    .HasConstraintName("supplier_contact_info_id_fkey");
            });

            modelBuilder.Entity<SupplierInfo>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("supplier_info_pkey");

                entity.ToTable("supplier_info");

                entity.HasIndex(e => e.EmailAddress, "supplier_info_email_address_key").IsUnique();

                entity.HasIndex(e => e.PhoneNumber, "supplier_info_phone_number_key").IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.AddressId).HasColumnName("address_id");
                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .HasColumnName("email_address");
                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .HasColumnName("phone_number");
                entity.Property(e => e.UrlAddress)
                    .HasMaxLength(50)
                    .HasColumnName("url_address");

                entity.HasOne(d => d.Address).WithMany(p => p.SupplierInfos)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("supplier_info_address_id_fkey");
            });

            modelBuilder.Entity<TableInfo>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("table_info_pkey");

                entity.ToTable("table_info");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Seats).HasColumnName("seats");
                entity.Property(e => e.TableNumber).HasColumnName("table_number");
                entity.Property(e => e.TableStatusId).HasColumnName("table_status_id");

                entity.HasOne(d => d.TableStatus).WithMany(p => p.TableInfos)
                    .HasForeignKey(d => d.TableStatusId)
                    .HasConstraintName("table_info_table_status_id_fkey");
            });

            modelBuilder.Entity<TableReservation>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("table_reservation");

                entity.Property(e => e.ReservationId).HasColumnName("reservation_id");
                entity.Property(e => e.TableId).HasColumnName("table_id");

                entity.HasOne(d => d.Reservation).WithMany()
                    .HasForeignKey(d => d.ReservationId)
                    .HasConstraintName("table_reservation_reservation_id_fkey");

                entity.HasOne(d => d.Table).WithMany()
                    .HasForeignKey(d => d.TableId)
                    .HasConstraintName("table_reservation_table_id_fkey");
            });

            modelBuilder.Entity<TableStatus>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("table_status_pkey");

                entity.ToTable("table_status");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<UserAddress>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("user_address");

                entity.Property(e => e.AddressId).HasColumnName("address_id");
                entity.Property(e => e.IsDefault)
                    .HasDefaultValue(false)
                    .HasColumnName("is_default");
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Address).WithMany()
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("user_address_address_id_fkey");

                entity.HasOne(d => d.User).WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_address_user_id_fkey");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("user_info_pkey");

                entity.ToTable("user_info");

                entity.HasIndex(e => e.EmailAddress, "user_info_email_address_key").IsUnique();

                entity.HasIndex(e => e.PhoneNumber, "user_info_phone_number_key").IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("created_at");
                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .HasColumnName("email_address");
                entity.Property(e => e.HashedPassword)
                    .HasMaxLength(255)
                    .HasColumnName("hashed_password");
                entity.Property(e => e.LastOrderAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("last_order_at");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .HasColumnName("phone_number");
                entity.Property(e => e.Salt)
                    .HasMaxLength(1024)
                    .HasColumnName("salt");
            });

            modelBuilder.Entity<UserNotificaiton>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("user_notificaiton");

                entity.Property(e => e.NotificationId).HasColumnName("notification_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Notification).WithMany()
                    .HasForeignKey(d => d.NotificationId)
                    .HasConstraintName("user_notificaiton_notification_id_fkey");

                entity.HasOne(d => d.User).WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_notificaiton_user_id_fkey");
            });

            modelBuilder.Entity<UserPromocode>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("user_promocode");

                entity.Property(e => e.PromocodeId).HasColumnName("promocode_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Promocode).WithMany()
                    .HasForeignKey(d => d.PromocodeId)
                    .HasConstraintName("user_promocode_promocode_id_fkey");

                entity.HasOne(d => d.User).WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_promocode_user_id_fkey");
            });

            modelBuilder.Entity<UserRefreshToken>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("user_refresh_token_pkey");

                entity.ToTable("user_refresh_token");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("created_at");
                entity.Property(e => e.ExpiresAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("expires_at");
                entity.Property(e => e.Token)
                    .HasMaxLength(255)
                    .HasColumnName("token");
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User).WithMany(p => p.UserRefreshTokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_refresh_token_user_id_fkey");
            });

            modelBuilder.Entity<UserReview>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("user_review_pkey");

                entity.ToTable("user_review");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Comment)
                    .HasMaxLength(255)
                    .HasColumnName("comment");
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("created_at");
                entity.Property(e => e.OrderId).HasColumnName("order_id");
                entity.Property(e => e.RatingValue).HasColumnName("rating_value");
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Order).WithMany(p => p.UserReviews)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("user_review_order_id_fkey");

                entity.HasOne(d => d.User).WithMany(p => p.UserReviews)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_review_user_id_fkey");
            });

            modelBuilder.Entity<UserReviewCriterion>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("user_review_criteria_pkey");

                entity.ToTable("user_review_criteria");

                entity.HasIndex(e => e.Name, "user_review_criteria_name_key").IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.IsPositive).HasColumnName("is_positive");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("user_role_pkey");

                entity.ToTable("user_role");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.RoleId).HasColumnName("role_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("user_role_role_id_fkey");

                entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_role_user_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
